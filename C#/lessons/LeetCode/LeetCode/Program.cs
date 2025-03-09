namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _6_ZigzagConversion test = new _6_ZigzagConversion();
            Console.WriteLine(test.Convert("Abdullokhon", 3));
            Console.WriteLine(test.Convert("PAYPALISHIRING", 3));
            Console.WriteLine(test.Convert("PAYPALISHIRING", 4));
        }
    }
}
