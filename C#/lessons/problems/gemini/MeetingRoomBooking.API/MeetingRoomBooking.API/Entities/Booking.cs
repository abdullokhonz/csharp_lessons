namespace MeetingRoomBooking.API.Entities;

public class Booking
{
    public Guid Id { get; set; }
    public Guid MeetingRoomId { get; set; }
    public MeetingRoom? MeetingRoom { get; set; }

    public Guid EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}