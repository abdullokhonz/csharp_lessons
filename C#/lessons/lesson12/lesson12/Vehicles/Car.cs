namespace lesson12.Vehicles
{
    public class Car : Vehicle
    {
        public string? Model { get; set; }

        public Car(string? brand) : base(brand) { }
        public Car(string? brand, string? model) : base(brand) { Model = model; }
    }
}
