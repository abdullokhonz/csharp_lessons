namespace StoreLoyaltySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Client client = new Client
            {
                Id = 1,
                Name = "John Doe",
                OrdersCount = 12,
                isVIP = true
            };

            decimal totalSum = 6000m;
            decimal finalPrice = CalculateFinalPrice(totalSum, client.OrdersCount, client.isVIP);
            Console.WriteLine($"Final price for {client.Name}: {finalPrice:C}");
        }

        static decimal CalculateFinalPrice(decimal totalSum, int clientOrdersCount, bool isVIP)
        {
            decimal totalDiscount = 0m;

            if (clientOrdersCount > 10) totalDiscount += 0.05m; // 5% discount for more than 10 orders
            if (isVIP) totalDiscount += 0.10m; // 10% discount for VIP clients
            if (totalSum > 5000) totalDiscount += 0.03m; // 3% discount for total sum greater than 5000

            if (totalDiscount > 0.15m) totalDiscount = 0.15m; // Maximum discount is 15%

            decimal price = totalSum * (1 - totalDiscount);

            return price;
        }
    }
}
