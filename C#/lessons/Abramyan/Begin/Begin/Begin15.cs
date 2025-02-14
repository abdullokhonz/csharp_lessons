namespace Begin
{
    public class Begin15
    {
        public static string Begin(double s)
        {
            double r = Math.Sqrt(s / Math.PI);
            double d = 2 * r;
            double l = 2 * Math.PI * r;
            return $"{d}, {l}";
        }
    }
}
