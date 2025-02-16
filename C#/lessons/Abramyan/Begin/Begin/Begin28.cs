namespace Begin
{
    public class Begin28
    {
        public static (double, double, double, double, double) Begin(double A)
        {
            double A2 = A * A;

            double A3 = A2 * A;

            double A5 = A3 * A2;

            double A10 = A5 * A5;

            double A15 = A10 * A5;

            return (A2, A3, A5, A10, A15);
        }
    }
}
