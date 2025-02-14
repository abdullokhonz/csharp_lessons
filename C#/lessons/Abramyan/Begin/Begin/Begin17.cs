namespace Begin
{
    public class Begin17
    {
        public static string Begin(int a, int b, int c)
        {
            int ac = Math.Abs(a - c);
            int bc = Math.Abs(b - c);
            return $"{ac}, {bc}, {ac + bc}";
        }
    }
}
