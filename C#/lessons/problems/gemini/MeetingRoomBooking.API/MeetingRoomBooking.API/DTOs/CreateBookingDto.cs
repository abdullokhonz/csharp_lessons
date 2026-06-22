using System.ComponentModel.DataAnnotations;

namespace MeetingRoomBooking.API.DTOs;

public record CreateBookingDto(
    [Required(ErrorMessage = "ID комнаты обязателен.")]
    Guid MeetingRoomId,

    [Required(ErrorMessage = "ID сотрудника обязателен.")]
    Guid EmployeeId,

    [Required]
    DateTime StartTime,

    [Required]
    DateTime EndTime
);