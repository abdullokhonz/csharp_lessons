namespace Begin
{
    public class Begin40
    {
        public static (double, double) Begin(double A1, double B1, double C1, double A2, double B2, double C2)
        {
            double D = A1 * B2 - A2 * B1;

            double x = (C1 * B2 - C2 * B1) / D;
            double y = (A1 * C2 - A2 * C1) / D;

            return (x, y);
        }
    }
}
