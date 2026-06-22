using System.ComponentModel.DataAnnotations;

namespace MeetingRoomBooking.API.DTOs;

public record UpdateBookingDto(
    [Required] DateTime StartTime,
    [Required] DateTime EndTime
);