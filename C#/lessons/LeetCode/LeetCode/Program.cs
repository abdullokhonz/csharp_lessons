namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _35_SearchInsertPosition test = new _35_SearchInsertPosition();

            Console.WriteLine(test.SearchInsert([1, 3, 5, 6], 5));
            Console.WriteLine(test.SearchInsert([1, 3, 5, 6], 2));
        }
    }
}
