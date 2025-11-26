using ISP.Interfaces;

namespace ISP.Classes
{
    public class SimplePrinter : IPrinter
    {
        public void Print() => Console.WriteLine("Printing only");
    }
}
