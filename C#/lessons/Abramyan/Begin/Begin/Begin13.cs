namespace Begin
{
    public class Begin13
    {
        public static string Begin(int r1, int r2)
        {
            double s1 = Math.PI * Math.Pow(r1, 2);
            double s2 = Math.PI * Math.Pow(r2, 2);
            double s3 = s1 - s2;
            return $"{s1}, {s2}, {s3}";
        }
    }
}
