namespace Begin
{
    public class Begin36
    {
        public static double Begin(double V1, double V2, double S, double T)
        {
            double totalSpeed = V1 + V2;

            double newDistance = S + (totalSpeed * T);

            return newDistance;
        }
    }
}
