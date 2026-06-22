namespace MeetingRoomBooking.API.Entities;

public class MeetingRoom
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public int Capacity { get; set; }
    
    public bool IsDeleted { get; set; }
    
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}