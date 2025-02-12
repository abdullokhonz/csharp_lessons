namespace lesson12.Animals
{
    public class Animal
    {
        public string? Name { get; set; }

        public Animal(string? name) => Name = name;

        public void MakeSound() => Console.WriteLine("Animal sound");
    }
}
