namespace Begin
{
    public class Begin14
    {
        public static string Begin(double l)
        {
            double r = l / (2 * Math.PI);
            l = 2 * Math.PI * r;
            double s = Math.PI * Math.Pow(r, 2);
            return $"{r}, {l}, {s}";
        }
    }
}
