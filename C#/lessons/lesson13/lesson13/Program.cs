namespace lesson13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ex - 1
            /*Animal animal = new Animal();
            Dog dog = new Dog();
            Cat cat = new Cat();
            Bird bird = new Bird();

            Animal[] animals = { animal, dog, cat, bird };

            foreach (var item in animals)
            {
                item.MakeSound();
            }*/

            // Ex - 2
            /*Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());

            IsFizzBuzz(num);*/
        }

        static void IsFizzBuzz(int num)
        {
            if (num % 3 == 0 && num % 5 == 0) Console.WriteLine("FizzBuzz");
            else if (num % 3 == 0) Console.WriteLine("Fizz");
            else if (num % 5 == 0) Console.WriteLine("Buzz");
            else Console.WriteLine("Empty string");
        }
    }
}
