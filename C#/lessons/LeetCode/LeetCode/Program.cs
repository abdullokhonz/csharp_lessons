namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _41_FirstMissingPositive test= new _41_FirstMissingPositive();

            Console.WriteLine(test.FirstMissingPositive([1, 2, 0]));
            Console.WriteLine(test.FirstMissingPositive([3, 4, -1, 1]));
            Console.WriteLine(test.FirstMissingPositive([7, 8, 9, 11, 12]));
        }
    }
}
