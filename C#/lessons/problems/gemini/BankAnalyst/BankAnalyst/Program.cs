namespace BankAnalyst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[] transactions = new int[] { 1000, -500, 2000, -1500, 3000, -2500, 4000, -3500, 5000, -4500, 150000 };

            BankReportService service = new BankReportService(transactions);

            service.PrintReport();
        }
    }
}
