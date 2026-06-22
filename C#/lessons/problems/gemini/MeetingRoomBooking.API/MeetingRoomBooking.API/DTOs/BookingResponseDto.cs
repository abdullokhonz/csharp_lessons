namespace MeetingRoomBooking.API.DTOs;

public record BookingResponseDto(
    Guid Id,
    Guid MeetingRoomId,
    string MeetingRoomName,
    Guid EmployeeId,
    string EmployeeName,
    DateTime StartTime,
    DateTime EndTime
);