namespace lesson10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Person person = new Person();
            person.Age = 10;
            person.Display();*/

            // Ex - 1
            /*Point point = new Point(8, 12);
            point.DistanceTo();*/

            // Ex - 2
            Library book = new Library
            {
                Title = "English",
                Author = "William Sh.",
                Year = 1892,
                isAvailable = true
            };
            book.BookInfo();
            book.BookAvailabilitySwitch();
            book.BookInfo();
        }
    }
}
