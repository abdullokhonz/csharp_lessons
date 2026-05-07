namespace TemperatureControlSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double[] temperatures = new double[] { 20.5, 22.3, 19.8, 51.4, 23.5, 17.8, 18.9, 25.2, 26.7, 27.5 };

            TemperatureControlService service = new TemperatureControlService(temperatures.ToList());

            var report = service.TemperatureSensorReport();
            service.PrintReport(report);
        }
    }
}
