namespace TemperatureDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(CountAnomalies(new int[] { 20, 21, 15, 14, 22 }));
        }

        static int CountAnomalies(int[] temperatures)
        {
            if (temperatures == null || temperatures.Length <= 1) return 0;

            int count = 0;
            int temp = temperatures[0];

            for (int i = 1; i < temperatures.Length; i++)
            {
                if (Math.Abs(temperatures[i] - temp) > 5)
                {
                    count++;
                }

                temp = temperatures[i];
            }

            return count;
        }
    }
}
