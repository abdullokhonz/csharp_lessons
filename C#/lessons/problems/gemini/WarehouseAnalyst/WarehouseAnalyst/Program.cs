namespace WarehouseAnalyst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(CountDuplicates(new int[] { 101, 102, 101, 103, 104, 102 }));
        }

        static int CountDuplicates(int[] itemIds)
        {
            Array.Sort(itemIds);

            int duplicateArticles = 0;

            for (int i = 0; i < itemIds.Length; i++)
            {
                int count = 1;
                bool hasDuplicate = false;

                while (i + 1 < itemIds.Length && itemIds[i] == itemIds[i + 1])
                {
                    count++;
                    i++;
                    hasDuplicate = true;
                }

                if (hasDuplicate) duplicateArticles++;

                if (count > 1)
                {
                    Console.WriteLine($"Item ID {itemIds[i]} appears {count} times.");
                }
            }

            return duplicateArticles;
        }
    }
}
