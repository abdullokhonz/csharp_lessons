namespace lesson13
{
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Animal Sound");
        }
    }

    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof");
        }
    }

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
    }

    public class Bird : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Chik");
        }
    }
}
