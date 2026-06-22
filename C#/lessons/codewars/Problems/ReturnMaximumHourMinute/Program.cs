namespace ReturnMaximumHourMinute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(MaxHourMinute.Max(new int[] { 1, 5, 3, 9, 7 })); // "19:59"
        }
    }
}
