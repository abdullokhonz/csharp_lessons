namespace Begin
{
    public class Begin21
    {
        public static string Begin(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double a = Distance(x1, y1, x2, y2);
            double b = Distance(x2, y2, x3, y3);
            double c = Distance(x3, y3, x1, y1);

            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p  - a) * (p - b) * (p - c));

            return $"{p:F2}, {s:F2}";
        }

        static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
