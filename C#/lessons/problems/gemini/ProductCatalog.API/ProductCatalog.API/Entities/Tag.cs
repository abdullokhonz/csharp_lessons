namespace ProductCatalog.API.Entities
{
    // Тема 5.4: Сущность Тега
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Навигационное свойство: Много тегов -> Много товаров (Many-to-Many)
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
