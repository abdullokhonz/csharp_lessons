using ISP.Interfaces;

namespace ISP.Classes
{
    public class AllInOnePrinter : IPrinter, IScanner, IFax
    {
        public void Print() => Console.WriteLine("Printing...");
        public void Scan() => Console.WriteLine("Scanning...");
        public void Fax() => Console.WriteLine("Faxing...");
    }
}
