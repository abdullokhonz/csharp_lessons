namespace _2404.MostFrequentEvenElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(MostFrequentEven(new int[] { 0, 1, 2, 2, 4, 4, 1 }));
            Console.WriteLine(MostFrequentEven(new int[] { 4, 4, 4, 9, 2, 4 }));
            Console.WriteLine(MostFrequentEven(new int[] { 29, 47, 21, 41, 13, 37, 25, 7 }));
        }

        public static int MostFrequentEven(int[] nums)
        {
            if (nums == null || nums.Length == 0) return -1;

            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if ((nums[i] & 1) == 0)
                {
                    if (map.ContainsKey(nums[i]))
                    {
                        map[nums[i]]++;
                    }
                    else
                    {
                        map[nums[i]] = 1;
                    }
                }
            }

            if (map.Count == 0) return -1;

            int maxFrequency = 0;
            int result = -1;

            foreach (var kvp in map)
            {
                if (kvp.Value > maxFrequency || (kvp.Value == maxFrequency && kvp.Key < result))
                {
                    maxFrequency = kvp.Value;
                    result = kvp.Key;
                }
            }

            return result;
        }
    }
}
