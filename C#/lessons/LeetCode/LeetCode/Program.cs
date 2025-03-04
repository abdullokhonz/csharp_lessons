namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _3_LongestSubstringWithoutRepeatingCharacters test = new _3_LongestSubstringWithoutRepeatingCharacters();
            Console.WriteLine(test.LengthOfLongestSubstring("abcabcbb"));
            Console.WriteLine(test.LengthOfLongestSubstring("pwwkew"));
            Console.WriteLine(test.LengthOfLongestSubstring("bbbb"));
            Console.WriteLine(test.LengthOfLongestSubstring("au"));
            Console.WriteLine(test.LengthOfLongestSubstring("aab"));
        }
    }
}
