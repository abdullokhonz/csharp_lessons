namespace TemperatureControlSystem
{
    public class TemperatureControlService
    {
        private readonly List<double> _temperatures;

        public TemperatureControlService(List<double> temperatures)
        {
            _temperatures = temperatures ?? throw new ArgumentNullException(nameof(temperatures));
        }

        public (double, int, bool) TemperatureSensorReport()
        {
            double averageTemperature = _temperatures.Average();
            int deviationsCount = 0;
            bool isEmergency = false;

            foreach (double temperatue in _temperatures)
            {
                if (temperatue < 18.0 || temperatue > 25.0) deviationsCount++;
                if (temperatue > 50.0) isEmergency = true;
            }

            var report = (averageTemperature, deviationsCount, isEmergency);

            return report;
        }

        public void PrintReport((double, int, bool) report)
        {
            Console.WriteLine($"Average Temperature: {report.Item1}");
            Console.WriteLine($"Deviations Count: {report.Item2}");
            Console.WriteLine($"Is Emergency: {report.Item3}");
        }
    }
}
