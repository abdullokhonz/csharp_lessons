namespace WarehouseManager
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Подготовка данных
            var items = new List<IItem>
            {
                new Electronics(1, "iPhone 15"),
                new Food(2, "Молоко", 1), // Скидка 50%
                new Food(3, "Хлеб", 10),
                new Electronics(1, "iPhone 15") // Дубликат для словаря
            };

            // Массив для XOR (все по паре, кроме ID 99)
            int[] sequenceWithLostId = { 10, 20, 99, 10, 20 };

            var service = new WarehouseService();

            // Выполнение логики
            service.ProcessInventory(items, sequenceWithLostId);

            // Вывод цен (Полиморфизм)
            Console.WriteLine("\n--- Цены со скидками/налогами ---");
            foreach (var item in items)
            {
                // Предположим базовая цена у всех 1000
                Console.WriteLine($"{item.Name}: {item.GetValue(1000):C}");
            }

            service.SaveReport(items, "warehouse_report.txt");
        }
    }
}
