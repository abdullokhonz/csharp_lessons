using System.Text;

namespace LeetCode
{
    public class _6_ZigzagConversion
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1 || numRows >= s.Length)
                return s;

            string[] rows = new string[numRows];
            int index = 0, step = 1;

            foreach (char c in s)
            {
                rows[index] += c;
                if (index == 0) step = 1;
                if (index == numRows - 1) step = -1;
                index += step;
            }

            StringBuilder result = new StringBuilder();
            foreach (string row in rows)
            {
                result.Append(row);
            }

            return result.ToString();
        }
    }
}
