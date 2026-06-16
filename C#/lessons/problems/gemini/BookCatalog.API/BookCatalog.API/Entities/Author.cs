using System.ComponentModel.DataAnnotations;

namespace BookCatalog.API.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [MaxLength(250, ErrorMessage = "Full name cannot exceed 250 characters.")]
        public string FullName { get; set; } = string.Empty;
    }
}
