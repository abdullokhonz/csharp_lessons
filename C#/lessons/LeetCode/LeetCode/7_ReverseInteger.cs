namespace LeetCode
{
    public class _7_ReverseInteger
    {
        public int Reverse(int x)
        {
            bool isNegative = x < 0;
            long absX = Math.Abs((long)x);
            string reversedStr = new string(absX.ToString().Reverse().ToArray());

            if (!long.TryParse(reversedStr, out long reversedX))
            {
                return 0;
            }

            reversedX = isNegative ? -reversedX : reversedX;

            return (reversedX >= int.MinValue && reversedX <= int.MaxValue) ? (int)reversedX : 0;
        }

        public int Reverse1(int x)
        {
            int s = x > 0 ? 1 : -1;
            long reversedX = long.Parse(new string((x * s).ToString().Reverse().ToArray())) * s;

            return (reversedX >= int.MinValue && reversedX <= int.MaxValue) ? (int)reversedX : 0;
        }

        public int Reverse2(int x)
        {
            bool isNegative = x < 0;
            string reversedStr = new string(Math.Abs(x).ToString().Reverse().ToArray());

            if (!long.TryParse(reversedStr, out long reversedX))
            {
                return 0;
            }

            reversedX = isNegative ? -reversedX : reversedX;

            return (reversedX >= int.MinValue && reversedX <= int.MaxValue) ? (int)reversedX : 0;
        }
    }
}
