using BookCatalog.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookCatalog.API.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable(nameof(Book));

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasIndex(b => b.Isbn)
                .IsUnique();

            builder.Property(b => b.Isbn)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(b => b.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne<Author>()
                .WithMany()
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
