namespace Begin
{
    public class Begin37
    {
        public static double Begin(double V1, double V2, double S, double T)
        {
            double totalSpeed = V1 + V2;

            double totalPath = totalSpeed * T;

            double newDistance = Math.Abs(S - totalPath);

            return newDistance;
        }
    }
}
