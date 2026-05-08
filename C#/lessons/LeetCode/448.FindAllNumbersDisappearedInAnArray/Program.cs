namespace _448.FindAllNumbersDisappearedInAnArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IList<int> list1 = FindDisappearedNumbers(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
            Console.WriteLine(string.Join(", ", list1));

            IList<int> list2 = FindDisappearedNumbers(new int[] { 1, 1 });
            Console.WriteLine(string.Join(", ", list2));
        }

        public static IList<int> FindDisappearedNumbers(int[] nums)
        {
            IList<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] > 0)
                {
                    nums[index] = -nums[index];
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }
    }
}
