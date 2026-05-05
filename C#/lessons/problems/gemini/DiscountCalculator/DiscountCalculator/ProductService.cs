namespace DiscountCalculator
{
    public class ProductService
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Name = "Ноутбук", Price = 1000m, Category = Category.Electronics },
            new Product { Name = "Смартфон", Price = 500m, Category = Category.Electronics },
            new Product { Name = "Книга", Price = 20m, Category = Category.General },
            new Product { Name = "Ручка", Price = 5m, Category = Category.General }
        };

        public ProductService()
        {
            
        }

        public Product? GetProduct()
        {
            int counter = 0;

            Console.WriteLine("Список доступных продуктов: ");

            foreach (Product product in _products)
                Console.WriteLine($"{++counter}. {product.Name} - {product.Price:C} ({product.Category})");

            Console.Write("Выберите продукт по номеру: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _products.Count)
            {
                return _products[index - 1];
            }
            else
            {
                Console.WriteLine("Неверный выбор.");
                return null;
            }
        }
    }
}
