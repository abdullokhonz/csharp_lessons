namespace Begin
{
    public class Begin11
    {
        public static string Begin(int a, int b)
        {
            return $"" +
                $"{Math.Abs(a + b)}," +
                $"{Math.Abs(a - b)}," +
                $"{Math.Abs(a * b)}," +
                $"{(b != 0 ? Math.Abs(a / b) : 0)}";
        }
    }
}
