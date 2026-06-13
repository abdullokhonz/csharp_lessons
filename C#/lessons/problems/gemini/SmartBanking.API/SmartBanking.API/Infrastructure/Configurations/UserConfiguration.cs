using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBanking.API.Entities;

namespace SmartBanking.API.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.Property(u => u.BonusBalance).HasColumnType("decimal(18,2)");

        // Для PostgreSQL стандарт получения UTC времени — NOW() или CURRENT_TIMESTAMP
        builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql("NOW()");

        // Связь Many-to-Many настраивается одной строкой. Задаем красивое имя таблице
        builder.HasMany(u => u.Categories)
            .WithMany(c => c.Users)
            .UsingEntity(j => j.ToTable("UserCategories"));
    }
}
