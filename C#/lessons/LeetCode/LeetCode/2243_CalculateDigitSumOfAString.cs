using System.Text;

namespace LeetCode
{
    public class _2243_CalculateDigitSumOfAString
    {
        public string DigitSum(string s, int k)
        {
            while (s.Length > k)
            {
                List<string> groups = new List<string>();

                for (int i = 0; i < s.Length; i += k)
                {
                    int len = Math.Min(k, s.Length - i);
                    groups.Add(s.Substring(i, len));
                }

                StringBuilder sb = new StringBuilder();
                foreach (string group in groups)
                {
                    int sum = group.Sum(ch => ch - '0');
                    sb.Append(sum.ToString());
                }

                s = sb.ToString();
            }

            return s;
        }

    }
}
