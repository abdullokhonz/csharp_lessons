namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _33_SearchInRotatedSortedArray test = new _33_SearchInRotatedSortedArray();

            Console.WriteLine(test.Search([4, 5, 6, 7, 0, 1, 2], 0));
            Console.WriteLine(test.Search([4, 5, 6, 7, 0, 1, 2], 3));
            Console.WriteLine(test.Search([1], 0));
            Console.WriteLine(test.Search([1], 1));
        }
    }
}
