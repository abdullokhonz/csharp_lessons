namespace ProductCatalog.API.Entities
{
    // Тема 5.4: Сущность Товара с поддержкой Мягкого Удаления
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        // Мягкое удаление (Флаг софт-делеmarks)
        public bool IsDeleted { get; set; }

        // Внешний ключ и навигационное свойство для Категории
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        // Навигационное свойство для Тегов (Many-to-Many)
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
