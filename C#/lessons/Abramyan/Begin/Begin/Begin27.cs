namespace Begin
{
    public class Begin27
    {
        public static (double, double, double) Begin(double A)
        {
            double A2 = A * A;
            double A4 = A2 * A2;
            double A8 = A4 * A4;

            return (A2, A4, A8);
        }
    }
}
