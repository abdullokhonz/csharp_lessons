using OrderManager.Entities;
using OrderManager.Interfaces;
using OrderManager.Services;

namespace OrderManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Выбираем конкретные реализации (можно легко заменить на другие)
            IRepository repo = new SqlRepository();
            INotificationService notification = new EmailService();

            // Собираем процессор, "впрыскивая" в него зависимости
            OrderProcessor processor = new OrderProcessor(repo, notification);

            Order myOrder = new Order { Id = 1, Items = new List<string> { "Laptop", "Mouse" } };
            processor.Process(myOrder);
        }
    }
}
