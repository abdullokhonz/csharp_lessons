using MeetingRoomBooking.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingRoomBooking.API.Infrastructure.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);

        // Связь One-to-Many: Комната -> Много Броней
        builder.HasOne(b => b.MeetingRoom)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.MeetingRoomId)
            .OnDelete(DeleteBehavior.Cascade); // Если комната удаляется физически, то и брони тоже

        // Связь One-to-Many: Сотрудник -> Много Броней
        builder.HasOne(b => b.Employee)
            .WithMany(e => e.Bookings)
            .HasForeignKey(b => b.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}