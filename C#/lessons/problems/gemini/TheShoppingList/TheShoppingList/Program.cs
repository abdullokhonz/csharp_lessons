namespace TheShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            List<string> purchases = new List<string>();

            for (byte i = 0; i < 3; i++)
            {
                Console.Write($"Введите название {i + 1} купленного товара: ");
                purchases.Add(Console.ReadLine()!);
            }

            if (purchases.Contains("хлеб"))
                Console.WriteLine("Вы купили хлеб");

            Console.WriteLine("Список купленных товаров:");
            foreach (var item in purchases)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }
}
