namespace _1.TwoSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Print(TwoSum(new int[] { 2, 7, 11, 15 }, 9));
            Print(TwoSum(new int[] { 3, 2, 4 }, 6));
            Print(TwoSum(new int[] { 3, 3 }, 6));
            Print(TwoSum(new int[] { 3, 2, 3 }, 6));
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }

                map[nums[i]] = i;
            }

            return new int[0];
        }

        public static void Print(int[] nums)
        {
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
