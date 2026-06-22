using MeetingRoomBooking.API.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBooking.API.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomsController(BookingDbContext context) : ControllerBase
{
    // 1. SOFT DELETE (Мягкое удаление комнаты)
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> SoftDelete(Guid id)
    {
        var room = await context.MeetingRooms.FirstOrDefaultAsync(r => r.Id == id);
        if (room == null) return NotFound();

        // Вместо физического удаления взводим флаг
        room.IsDeleted = true;
        
        await context.SaveChangesAsync();
        return NoContent();
    }

    // 2. GET ARCHIVED (Получение только софт-удаленных комнат)
    [HttpGet("archived")]
    public async Task<IActionResult> GetArchived()
    {
        // Сбрасываем глобальный фильтр "!IsDeleted", чтобы увидеть удаленные записи
        var archivedRooms = await context.MeetingRooms
            .AsNoTracking()
            .IgnoreQueryFilters() 
            .Where(r => r.IsDeleted == true)
            .ToListAsync();

        return Ok(archivedRooms);
    }
}