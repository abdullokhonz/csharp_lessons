namespace LeetCode
{
    public class _8_StringToInteger
    {
        public int MyAtoi(string s)
        {
            s = s.Trim();

            if (s == "") return 0;

            int sign = 1;
            if (s[0] == '-')
            {
                sign = -1;
                s = s.Substring(1);
            }
            else if (s[0] == '+') s = s.Substring(1);

            int result = 0;
            int intMax = (int)Math.Pow(2, 31) - 1;
            int intMin = (int)Math.Pow(2, 31) * -1;

            foreach (char item in s)
            {
                if (Char.IsDigit(item))
                {
                    if (result > intMax / 10 || (result == intMax / 10 && item - '0' > intMax % 10))
                    {
                        return sign == 1 ? intMax : intMin;
                    }

                    result = result * 10 + (item - '0');
                }
                else
                {
                    break;
                }
            }

            result *= sign;

            if (result < intMin) return intMin;
            if (result > intMax) return intMax;

            return result;
        }
    }
}
