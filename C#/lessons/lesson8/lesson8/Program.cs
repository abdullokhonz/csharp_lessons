namespace lesson8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*House house = new House()
            {
                size = 300.0,
                kitchen = "furniture",
                color = "white",
            };  

            *//*house.size = 300.0;
            house.kitchen = "furniture";
            house.color = "white"*//*;

            Console.WriteLine($"Size: {house.size}\nKitchen: {house.kitchen}\nColor: {house.color}");*/

            // Ex - 1
            /*Person person = new Person()
            {
                name = "Michael",
                age = 17,
            };

            Console.WriteLine(person.PrintInfo());
            Console.WriteLine(person.HaveBirthday());
            Console.WriteLine(person.PrintInfo());*/

            // Ex - 2
            /*Book book = new Book()
            {
                title = "How to be a FullStack Dev?",
                author = "FullStack Developer",
                pages = 1250,
            };

            Console.WriteLine(book.PrintBookInfo());
            Console.WriteLine(book.IsBigBook());*/

            // Ex - 3
            Rectangle rectangle = new Rectangle()
            {
                width = 12.8f,
                height = 8.8f,
            };

            Console.WriteLine("Area of rectangle: " + rectangle.GetArea());
            Console.WriteLine("Perimeter of rectangle: " + rectangle.GetPerimeter());

            Console.WriteLine();

            rectangle.Main();
        }
    }
}
