using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.API.DTOs
{
    // Тема 4.4, 4.6: Модель (DTO) для создания товара с DataAnnotations валидацией
    public record CreateProductDto(
        [Required(ErrorMessage = "Имя продукта обязательно.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Имя должно быть от 3 до 150 символов.")]
        string Name,

        [Range(0.01, 100000.00, ErrorMessage = "Цена должна быть в диапазоне от 0.01 до 100 000.")]
        decimal Price,

        [Required]
        int CategoryId,

        // Список ID тегов, которые мы хотим привязать к товару
        List<int> TagIds
    );
}
