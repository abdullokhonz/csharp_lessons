namespace Begin
{
    public class Begin35
    {
        public static double Begin(double V, double U, double T1, double T2)
        {
            double S1 = V * T1;

            double S2 = (V - U) * T2;

            double S = S1 + S2;

            return S;
        }
    }
}
