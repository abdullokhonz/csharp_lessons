namespace lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            int FirstNumber = 8;
            int SecondNumber = 12;
            Console.WriteLine(FirstNumber + SecondNumber); 
            */
            /*
            Console.Write("Введите число для расчёта периметра квадрата: ");
            int Square = Convert.ToInt32(Console.ReadLine());
            int result = Square * 4;
            Console.WriteLine(result);
            */
            /*
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}");
            */

            // Homework

            // Ex - 1
            /*
            Console.Write("Enter the first side of the rectangle: ");
            int sideA = Convert.ToInt32 (Console.ReadLine());

            Console.Write("Enter the second side of the rectangle: ");
            int sideB = Convert.ToInt32 (Console.ReadLine());

            int perimeter = 2 * (sideA + sideB);
            int area = sideA * sideB;

            Console.WriteLine(
                $"First side of the rectangle: {sideA}\n" +
                $"Second side of the rectangle: {sideB}\n" +
                $"Perimeter of a rectangle: {perimeter}\n" +
                $"Area of a rectangle: {area}"
            );
            */

            // Ex - 2
            /*
            Console.Write("Enter the first number: ");
            int firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int secondNumber = Convert.ToInt32(Console.ReadLine());

            int sum = firstNumber + secondNumber;
            int difference = firstNumber - secondNumber;
            int product = firstNumber * secondNumber;
            double quotientOfTheirSquares = (Math.Pow(firstNumber, 2)) / (Math.Pow(secondNumber, 2));

            Console.WriteLine(
                $"Sum of numbers: {sum}\n" +
                $"Difference of numbers: {difference}\n" +
                $"Product of numbers: {product}\n" +
                $"Quotient of their squares: {quotientOfTheirSquares}"
            );
            */

            // Ex - 3
            /*
            Console.Write("Enter the area of the circle: ");
            int s = Convert.ToInt32(Console.ReadLine());

            double d = Math.Sqrt(4 * s / Math.PI);
            double l = Math.PI * d;

            Console.WriteLine(
                $"Circle diameter: {d}\n" +
                $"Circumference of a circle: {l}"
            );
            */

            // Ex - 4
            /*
            Console.Write("Enter distance in centimeters: ");
            int l = Convert.ToInt32(Console.ReadLine());

            double result = l / 100.0;

            Console.WriteLine($"{l} centimeters = {result} meters");
            */
        }
    }
}
