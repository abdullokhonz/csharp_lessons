namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _5_LongestPalindromicSubstring test = new _5_LongestPalindromicSubstring();
            Console.WriteLine(test.LongestPalindrome("babad"));
            Console.WriteLine(test.LongestPalindrome("cbbd"));
        }
    }
}
