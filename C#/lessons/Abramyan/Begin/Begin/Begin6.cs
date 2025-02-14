namespace Begin
{
    public class Begin6
    {
        public static string Begin(int a, int b, int c)
        {
            int v = a * b * c;
            int s = 2 * (a * b + b * c + a * c);
            return $"{v}, {s}";
        }
    }
}
