namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _4_MedianOfTwoSortedArrays test = new _4_MedianOfTwoSortedArrays();
            Console.WriteLine(test.FindMedianSortedArrays([1, 3], [2]));
            Console.WriteLine(test.FindMedianSortedArrays([1, 2], [3, 4]));
            Console.WriteLine(test.FindMedianSortedArrays([], [1]));
        }
    }
}
