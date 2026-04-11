namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _28_FindTheIndexOfTheFirstOccurrenceInAString test = new _28_FindTheIndexOfTheFirstOccurrenceInAString();

            Console.WriteLine(test.StrStr("sadbutsad", "sad"));
            Console.WriteLine(test.StrStr("leetcode", "leeto"));
        }
    }
}
