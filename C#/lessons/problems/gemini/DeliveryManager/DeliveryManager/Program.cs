namespace DeliveryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Product product = new Product
            {
                Id = 1,
                Name = "Glass Vase",
                Weight = 2.5,
                Distance = 150.0,
                IsFragile = true
            };

            DeliveryService service = new DeliveryService(product);

            decimal shippingCost = service.CalculateShippingCost();
            Console.WriteLine($"Shipping cost for {product.Name}: {shippingCost:C}");
        }
    }
}
