using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.API.DTOs
{
    // Теma 4.4, 4.6: Модель для обновления товара
    public record UpdateProductDto(
        [Required] string Name,
        [Range(0.01, 100000.00)] decimal Price,
        [Required] int CategoryId,
        List<int> TagIds
    );
}
