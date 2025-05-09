namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _66_PlusOne test = new _66_PlusOne();

            Console.WriteLine(test.PlusOne([1, 2, 3]));
            Console.WriteLine(test.PlusOne([4, 3, 2, 1]));
            Console.WriteLine(test.PlusOne([9]));
            Console.WriteLine(test.PlusOne([9, 9, 9]));
        }
    }
}
