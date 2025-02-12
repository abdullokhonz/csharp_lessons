namespace lesson7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ex - 1
            /*Console.Write("Enter number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            double num2;

            PowerA3(num1, out num2);

            Console.WriteLine(num2);*/

            // Ex - 2
            /*Console.Write("Enter number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            double num2, num3, num4;

            PowerA234(num1, out num2, out num3, out num4);

            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);*/

            // Ex - 3
            /*Console.Write("Enter number X: ");
            double numX = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter number Y: ");
            double numY = Convert.ToDouble(Console.ReadLine());*/

            Console.Write("Enter number A: ");
            double numA = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter number B: ");
            double numB = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter number C: ");
            double numC = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter number D: ");
            double numD = Convert.ToDouble(Console.ReadLine());

            double numAMean, numGMean;

            double[] arr = { numA, numB, numC, numD };

            for (int i = 1; i < arr.Length; i++)
            {
                Mean(arr[0], arr[i], out numAMean, out numGMean);
                Console.WriteLine($"\nСреднее арифматическое {arr[0]} и {arr[i]}: {numAMean}");
                Console.WriteLine($"Среднее геометрическое {arr[0]} и {arr[i]}: {numAMean}\n");
            }
        }

        static void PowerA3(double a, out double b)
        {
            b = Math.Pow(a, 3);
        }

        static void PowerA234(double a, out double b, out double c, out double d)
        {
            b = Math.Pow(a, 2);
            c = Math.Pow(a, 3);
            d = Math.Pow(a, 4);
        }

        static void Mean(double x, double y, out double aMean, out double gMean)
        {
            aMean = (x + y) / 2;
            gMean = Math.Sqrt(x * y);
        }
    }
}
