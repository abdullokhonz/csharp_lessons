namespace LeetCode
{
    public class _3_LongestSubstringWithoutRepeatingCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {
            int start = 0, maxLength = 0;
            var window = new HashSet<char>();

            for (int end = 0; end < s.Length; end++)
            {
                char currentChar = s[end];

                while (window.Contains(currentChar))
                {
                    window.Remove(s[start]);
                    start++;
                }

                window.Add(currentChar);

                maxLength = Math.Max(maxLength, end - start + 1);
            }

            return maxLength;
        }
    }
}
