using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.API.Entities;

namespace ProductCatalog.API.Infrastructure.Configurations
{
    // Тема 5.4, 5.5: Конфигурация Товара
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");

            // Настройка связи One-to-Many (Категория -> Товары)
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Запрещаем удалять категорию, если в ней есть товары

            // Настройка связи Many-to-Many (Товары <-> Теги)
            // EF Core автоматически создаст промежуточную таблицу "ProductTag" под капотом
            builder.HasMany(p => p.Tags)
                .WithMany(t => t.Products);

            // 🔥 Сверхважно для Soft Delete: Глобальный фильтр запросов
            // Теперь все запросы к _context.Products будут автоматически игнорировать удаленные записи!
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
