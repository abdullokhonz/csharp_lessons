using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBanking.API.Entities;

namespace SmartBanking.API.Infrastructure.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.AccountNumber).IsRequired().HasMaxLength(20);
        builder.Property(a => a.Balance).HasColumnType("decimal(18,2)");

        // Уникальный индекс для быстрого поиска счетов
        builder.HasIndex(a => a.AccountNumber).IsUnique();

        // One-to-Many связь с Юзером и защита от каскадного удаления!
        builder.HasOne(a => a.User)
            .WithMany() // Навигационного свойства в User нет, оставляем пустым
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict); // Бизнес-требование!

        builder.HasOne(a => a.Category)
            .WithMany()
            .HasForeignKey(a => a.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
