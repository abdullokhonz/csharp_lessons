using MeetingRoomBooking.API.DTOs;
using MeetingRoomBooking.API.Entities;
using MeetingRoomBooking.API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBooking.API.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingsController(BookingDbContext context, ILogger<BookingsController> logger) : ControllerBase
{
    // 1. GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var bookings = await context.Bookings
            .AsNoTracking()
            .Include(b => b.MeetingRoom)
            .Include(b => b.Employee)
            .Select(b => new BookingResponseDto(
                b.Id,
                b.MeetingRoomId,
                b.MeetingRoom != null ? b.MeetingRoom.Name : "Удаленная комната",
                b.EmployeeId,
                b.Employee != null ? b.Employee.FullName : "Неизвестный сотрудник",
                b.StartTime,
                b.EndTime
            ))
            .ToListAsync();

        return Ok(bookings);
    }

    // 2. CREATE (С Явной транзакцией и бизнес-проверками)
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto dto)
    {
        if (dto.StartTime >= dto.EndTime)
        {
            return BadRequest(new { Message = "Время начала не может быть позже или равно времени окончания." });
        }

        // Открываем транзакцию
        await using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            // Проверяем существование комнаты (учитывая, что софт-удаленные отсекаются фильтром)
            var roomExists = await context.MeetingRooms.AnyAsync(r => r.Id == dto.MeetingRoomId);
            if (!roomExists)
            {
                logger.LogWarning("Попытка бронирования несуществующей или удаленной комнаты: {Id}", dto.MeetingRoomId);
                return NotFound(new { Message = "Указанная переговорная комната не найдена." });
            }

            // Проверяем существование сотрудника
            var employeeExists = await context.Employees.AnyAsync(e => e.Id == dto.EmployeeId);
            if (!employeeExists)
            {
                logger.LogWarning("Сотрудник с ID {Id} не найден в системе.", dto.EmployeeId);
                return NotFound(new { Message = "Сотрудник не найден." });
            }

            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                MeetingRoomId = dto.MeetingRoomId,
                EmployeeId = dto.EmployeeId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };

            context.Bookings.Add(booking);
            await context.SaveChangesAsync();

            // Фиксируем транзакцию
            await transaction.CommitAsync();

            return StatusCode(201, booking);
        }
        catch (Exception ex)
        {
            // В случае форс-мажора откатываем базу обратно
            await transaction.RollbackAsync();
            logger.LogError(ex, "Ошибка при создании бронирования. Транзакция откатана.");
            return StatusCode(500, "Ошибка при обработке транзакции.");
        }
    }

    // 3. PUT UPDATE
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookingDto dto)
    {
        if (dto.StartTime >= dto.EndTime)
        {
            return BadRequest(new { Message = "Некорректный интервал времени." });
        }

        var booking = await context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
        if (booking == null) return NotFound();

        booking.StartTime = dto.StartTime;
        booking.EndTime = dto.EndTime;

        await context.SaveChangesAsync();
        return NoContent();
    }

    // 4. HARD DELETE
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> HardDelete(Guid id)
    {
        var booking = await context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
        if (booking == null) return NotFound();

        context.Bookings.Remove(booking);
        await context.SaveChangesAsync();

        return NoContent();
    }
}