namespace LeetCode
{
    public class _3110_ScoreOfAString
    {
        public int ScoreOfString(string s)
        {
            int result = 0;

            for (int i = 0; i < s.Length - 1; i++)
                result += Math.Abs(s[i] - s[i + 1]);

            return result;
        }

        //public int ScoreOfString(string s)
        //{
        //    if (s == null) return 0;

        //    byte[] ascii = Encoding.ASCII.GetBytes(s);
        //    int result = 0;

        //    for (int i = 0; i < ascii.Length - 1; i++)
        //        result += Math.Abs(ascii[i] - ascii[i + 1]);

        //    return result;
        //}
    }
}
