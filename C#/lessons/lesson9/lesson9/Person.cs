namespace lesson9
{
    public class Person
    {
        public int age = 18;
        public string name = "Andrew";
        public double height = 180.5;

        public Person(int a, string n, double h)
        {
            Console.WriteLine("Создание объекта Person");
            age = a; name = n; height = h;
            Console.WriteLine($"Возраст: {a}\nИмя: {n}\nРост: {h}");
        }

        public Person(int a, string n)
        {
            Console.WriteLine("Создание объекта Person");
            age = a; name = n;
            Console.WriteLine($"Возраст: {a}\nИмя: {n}");
        }
    }
}
