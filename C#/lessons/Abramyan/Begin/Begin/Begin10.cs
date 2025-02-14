namespace Begin
{
    public class Begin10
    {
        public static string Begin(int a, int b)
        {
            return $"" +
                $"{a + b}," +
                $"{a - b}," +
                $"{a * b}," +
                $"{(b != 0 ? a / b : 0)}";
        }
    }
}
