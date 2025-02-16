namespace Begin
{
    public class Begin23
    {
        public static string Begin(int a, int b, int c)
        {
            (a, b, c) = (c, a, b);

            return $"{a}, {b}, {c}";
        }
    }
}
