namespace lesson12.Vehicles
{
    public class Vehicle
    {
        public string? Brand { get; set; }

        public Vehicle() => Brand = "Unknown";
        public Vehicle(string? brand) => Brand = brand;
    }
}
