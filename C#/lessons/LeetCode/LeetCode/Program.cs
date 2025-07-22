namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _2243_CalculateDigitSumOfAString test = new _2243_CalculateDigitSumOfAString();

            Console.WriteLine(test.DigitSum("11111222223", 3));
            Console.WriteLine(test.DigitSum("00000000", 3));
        }
    }
}
