using System.Runtime.InteropServices.ComTypes;
using MeetingRoomBooking.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeetingRoomBooking.API.Infrastructure.Data;

public class BookingDbContext(DbContextOptions<BookingDbContext> options) : DbContext(options)
{
    public DbSet<MeetingRoom>  MeetingRooms => Set<MeetingRoom>();
    
    public DbSet<Employee>  Employees => Set<Employee>();
    
    public DbSet<Booking>  Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookingDbContext).Assembly);
    }
}