namespace DeliveryManager
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Weight { get; set; }

        public double Distance { get; set; }

        public bool IsFragile { get; set; }
    }
}
