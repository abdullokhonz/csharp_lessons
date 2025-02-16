namespace Begin
{
    public class Begin22
    {
        public static string Begin(int a, int b)
        {
            (a, b) = (b, a);
            
            return $"{a}, {b}";

            //return $"{b}, {a}";
        }
    }
}
