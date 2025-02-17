namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _20_ValidParentheses validator = new _20_ValidParentheses();

            Console.WriteLine(validator.IsValid("()"));       // True
            Console.WriteLine(validator.IsValid("()[]{}"));   // True
            Console.WriteLine(validator.IsValid("(]"));       // False
            Console.WriteLine(validator.IsValid("([)]"));     // False
            Console.WriteLine(validator.IsValid("{[]}"));     // True
        }
    }
}
