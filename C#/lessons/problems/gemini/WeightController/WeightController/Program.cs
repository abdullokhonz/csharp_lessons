namespace WeightController
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(CalculateTotalWeight(new int[] { 30, 80, 10, 20 }));

            Console.WriteLine(CountMaxPackages(new int[] { 50, 10, 40, 20, 30 }));
        }

        static int CalculateTotalWeight(int[] packages)
        {
            int totalWeight = 100;
            int currentWeight = 0;

            foreach (int package in packages)
            {
                if ((totalWeight - currentWeight) >= package) currentWeight += package;
            }

            return currentWeight;
        }

        static int CountMaxPackages(int[] packages)
        {
            // Сортируем массив по возрастанию. 
            // Теперь самые легкие посылки в самом начале.
            Array.Sort(packages);

            int limit = 100;
            int count = 0;

            foreach (int package in packages)
            {
                // Проверяем, влезет ли текущая посылка
                if (limit >= package)
                {
                    limit -= package; // Уменьшаем доступный лимит
                    count++;          // Увеличиваем счетчик
                }
                else
                {
                    // Так как массив отсортирован, если текущая не влезла, 
                    // то все следующие (которые еще тяжелее) точно не влезут.
                    break;
                }
            }

            return count;
        }
    }
}
