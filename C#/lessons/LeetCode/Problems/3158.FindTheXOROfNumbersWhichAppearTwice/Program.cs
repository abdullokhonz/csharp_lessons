namespace _3158.FindTheXOROfNumbersWhichAppearTwice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(DuplicateNumbersXOR(new int[] { 1, 2, 1, 3 }));
            Console.WriteLine(DuplicateNumbersXOR(new int[] { 1, 2, 3 }));
            Console.WriteLine(DuplicateNumbersXOR(new int[] { 1, 2, 2, 1 }));
        }

        public static int DuplicateNumbersXOR(int[] nums)
        {
            var duplicates = nums.GroupBy(x => x)
                                 .Where(g => g.Count() > 1)
                                 .Select(g => g.Key)
                                 .ToList();

            int xor = 0;

            foreach (int num in duplicates) xor ^= num;

            return xor;
        }
    }
}
