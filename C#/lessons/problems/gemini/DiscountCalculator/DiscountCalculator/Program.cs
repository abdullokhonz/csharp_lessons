namespace DiscountCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            var service = new DiscountService();

            Console.WriteLine("--- Магазин 'Bookkeeping Electronics' ---");

            Console.Write("Введите цену товара: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price)) return;

            Console.Write("Это электроника? (y/n): ");
            bool isElectronics = Console.ReadLine()?.ToLower() == "y";

            Console.Write("У вас сегодня день рождения? (y/n): ");
            bool isBirthday = Console.ReadLine()?.ToLower() == "y";

            var product = new Product
            {
                Price = price,
                Category = isElectronics ? Category.Electronics : Category.General
            };

            decimal finalPrice = service.CalculateFinalPrice(product, isBirthday);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Начальная цена: {price:C}");
            Console.WriteLine($"Скидка составила: {(price - finalPrice):C}");
            Console.WriteLine($"Итого к оплате: {finalPrice:C}");
        }
    }
}
