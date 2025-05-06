namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _91_DecodeWays test = new _91_DecodeWays();

            Console.WriteLine(test.NumDecodings("12"));
            Console.WriteLine(test.NumDecodings("226"));
            Console.WriteLine(test.NumDecodings("06"));
        }
    }
}
