namespace lesson12.Animals
{
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        new public void MakeSound() => Console.WriteLine("Woof");
    }
}
