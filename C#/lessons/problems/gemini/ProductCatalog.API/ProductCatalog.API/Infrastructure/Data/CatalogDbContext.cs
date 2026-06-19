using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.Entities;
using System.Reflection.Emit;

namespace ProductCatalog.API.Infrastructure.Data
{
    // Тема 5.1, 5.2: Настройка контекста данных
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Tag> Tags => Set<Tag>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Автоматически применяем все конфигурации (включая ProductConfiguration) из текущей сборки
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
        }
    }
}
