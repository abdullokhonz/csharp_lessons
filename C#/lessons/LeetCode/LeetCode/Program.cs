namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _58_LengthOfLastWord test = new _58_LengthOfLastWord();

            Console.WriteLine(test.LengthOfLastWord("Hello World"));
            Console.WriteLine(test.LengthOfLastWord("   fly me   to   the moon  "));
            Console.WriteLine(test.LengthOfLastWord("luffy is still joyboy"));
        }
    }
}
