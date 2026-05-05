namespace DiscountCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            var productService = new ProductService();
            var service = new DiscountService();

            Console.WriteLine("--- Магазин 'Bookkeeping Electronics' ---");

            var product = productService.GetProduct();
            bool isBirthday = false;
            if (product == null)
            {
                Console.Write("Введите цену товара: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price)) return;

                Console.Write("Это электроника? (y/n): ");
                bool isElectronics = Console.ReadLine()?.ToLower() == "y";

                Console.Write("У вас сегодня день рождения? (y/n): ");
                isBirthday = Console.ReadLine()?.ToLower() == "y";

                product = new Product
                {
                    Price = price,
                    Category = isElectronics ? Category.Electronics : Category.General
                };
            }
            else
            {
                Console.Write("У вас сегодня день рождения? (y/n): ");
                isBirthday = Console.ReadLine()?.ToLower() == "y";
            }

            decimal finalPrice = service.CalculateFinalPrice(product, isBirthday);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Начальная цена: {product.Price:C}");
            Console.WriteLine($"Скидка составила: {(product.Price - finalPrice):C}");
            Console.WriteLine($"Итого к оплате: {finalPrice:C}");
        }
    }
}
