namespace LeetCode
{
    public class _13_RomanToInteger
    {
        public int RomanToInt(string s)
        {
            Dictionary<char, int> roman = new Dictionary<char, int>
            {
                { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 },
                { 'C', 100 }, { 'D', 500 }, { 'M', 1000 }
            };

            int total = 0, prevValue = 0;

            for (int i = s.Length; i > 0; i--)
            {
                int value = roman[s[i - 1]];
                if (value < prevValue) total -= value;
                else total += value;
                prevValue = value;
            }

            return total;
        }
    }
}