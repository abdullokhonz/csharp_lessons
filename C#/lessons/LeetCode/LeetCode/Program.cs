namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _1_TwoSum twoSum = new _1_TwoSum();
            int[] result = twoSum.TwoSum(new int[] { 2, 5, 7, 11, 15 }, 9);
            Console.WriteLine($"[{result[0]}, {result[1]}]");
        }
    }
}
