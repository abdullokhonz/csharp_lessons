namespace LeetCode
{
    public class _91_DecodeWays
    {
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0')
                return 0;

            int n = s.Length;
            int[] dp = new int[n + 1];

            dp[0] = 1; // пустая строка
            dp[1] = 1; // первая цифра != '0'

            for (int i = 2; i <= n; i++)
            {
                string oneDigit = s.Substring(i - 1, 1);
                string twoDigits = s.Substring(i - 2, 2);

                // Проверяем 1 цифру
                if (oneDigit != "0")
                    dp[i] += dp[i - 1];

                // Проверяем 2 цифры
                if (int.TryParse(twoDigits, out int num) && num >= 10 && num <= 26)
                    dp[i] += dp[i - 2];
            }

            return dp[n];
        }

        //public int NumDecodings2(string s)
        //{
        //    if (string.IsNullOrEmpty(s) || s[0] == '0')
        //        return 0;

        //    var alphabet = Enumerable.Range(1, 26)
        //        .ToDictionary(i => i, i => ((char)('A' + i - 1)).ToString());



        //    return 0;
        //}
    }
}
