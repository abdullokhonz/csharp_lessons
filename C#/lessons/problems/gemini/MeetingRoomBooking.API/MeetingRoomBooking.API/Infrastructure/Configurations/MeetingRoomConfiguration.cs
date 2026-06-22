using MeetingRoomBooking.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeetingRoomBooking.API.Infrastructure.Configurations;

public class MeetingRoomConfiguration : IEntityTypeConfiguration<MeetingRoom>
{
    public void Configure(EntityTypeBuilder<MeetingRoom> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Name).IsRequired().HasMaxLength(100);

        // 🔥 Глобальный фильтр для Soft Delete
        builder.HasQueryFilter(r => !r.IsDeleted);
    }
}