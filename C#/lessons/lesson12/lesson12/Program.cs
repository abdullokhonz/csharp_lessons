using lesson12.Animals;
using lesson12.Vehicles;

namespace lesson12
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*Person person = new Person
            {
                FirstName = "Leo",
                LastName = "Messi"
            };
            person.PrintName();

            Student student = new Student
            {
                FirstName = "Abdullo",
                LastName = "Ghaybulloev",
                Group = "C#"
            };
            student.PrintName();*/

            // Ex - 1
            /*Animal animal = new Animal("Doggy");
            Console.WriteLine(animal.Name);
            animal.MakeSound();
            Dog dog = new Dog("Buddy");
            Console.WriteLine(dog.Name);
            dog.MakeSound();*/

            // Ex - 2
            Vehicle vehicle = new Vehicle();
            Console.WriteLine(vehicle.Brand);

            Car car = new Car("BMW", "I8");
            Console.WriteLine(car.Brand + ", " + car.Model);
        }
    }
}
