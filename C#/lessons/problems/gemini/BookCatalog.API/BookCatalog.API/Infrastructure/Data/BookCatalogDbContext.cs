using BookCatalog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.API.Infrastructure.Data
{
    public class BookCatalogDbContext : DbContext
    {
        public BookCatalogDbContext(DbContextOptions<BookCatalogDbContext> options)
            : base(options)
        {

        }

        public DbSet<Author> Authors => Set<Author>();

        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookCatalogDbContext).Assembly);
        }
    }
}
