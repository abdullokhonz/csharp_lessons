namespace MeetingRoomBooking.API.Entities;

public class Employee
{
    public Guid Id { get; set; }
    
    public string FullName { get; set; } = string.Empty;
    
    public string Position { get; set; } = string.Empty;
    
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}