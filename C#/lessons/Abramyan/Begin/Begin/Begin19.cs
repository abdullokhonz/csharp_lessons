namespace Begin
{
    public class Begin19
    {
        public static string Begin(double x1, double y1, double x2, double y2)
        {
            double width = Math.Abs(x2 - x1);
            double height = Math.Abs(y2 - y1);
            double area = width * height;
            double perimeter = 2 * (width + height);
            return $"{perimeter}, {area}";
        }
    }
}
