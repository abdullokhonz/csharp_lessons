namespace ProductCatalog.API.DTOs
{
    // Тема 4.4: Плоская модель ответа, чтобы не возвращать клиенту тяжелые циклические сущности БД
    public record ProductResponseDto(
        Guid Id,
        string Name,
        decimal Price,
        string CategoryName,
        List<string> Tags
    );
}
