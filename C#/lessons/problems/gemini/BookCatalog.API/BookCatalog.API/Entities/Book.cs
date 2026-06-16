using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookCatalog.API.Entities
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(250, ErrorMessage = "Title cannot exceed 250 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required.")]
        [MaxLength(13, ErrorMessage = "ISBN cannot exceed 13 characters.")]
        public string Isbn { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
    }
}
