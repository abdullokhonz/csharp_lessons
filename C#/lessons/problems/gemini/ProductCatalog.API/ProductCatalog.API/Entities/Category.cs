namespace ProductCatalog.API.Entities
{
    // Тема 5.4: Сущность Категории
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Навигационное свойство: Одна категория -> Много товаров (One-to-Many)
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
