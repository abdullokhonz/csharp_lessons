namespace Begin
{
    public class Begin24
    {
        public static string Begin(int a, int b, int c)
        {
            (a, b, c) = (b, c, a);

            return $"{a}, {b}, {c}";
        }
    }
}
