namespace Begin
{
    public class Begin34
    {
        public static string Begin(double x, double a, double y, double b)
        {
            double priceX = a / x;
            double priceY = b / y;

            double moreExpensive = priceX - priceY;

            if (moreExpensive >= 0) return $"{priceX}, {priceY}, " +
                    $"Chocolates are more expensive than toffees at {moreExpensive}$";
            else return $"{priceX}, {priceY}, " +
                    $"Chocolates are cheaper than toffees at {moreExpensive * -1}$";
        }
    }
}
