namespace lesson6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Math math = new Math();

            Console.Write("Enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(math.CheckNumber(num));
            Console.WriteLine(math.ParityCheck(num));

            //---------------------

            Console.Write("Enter your age: ");
            uint age = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine(math.CheckAge(age));

            //---------------------

            Math calc = new Math();

            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter math operation: ");
            char oper = Convert.ToChar(Console.ReadLine());

            Console.WriteLine(calc.Calc(num1, num2, oper));
        }
    }

    public class Math
    {
        public int CheckNumber(int num)
        {
            if (num > 0) Console.WriteLine("Число положительное");
            else if (num < 0) Console.WriteLine("Число отрицательное");
            else Console.WriteLine("Это ноль");
            return num;
        }

        public string ParityCheck(int num)
        {
            return num % 2 == 0 ? "Число чётное." : "Число нечётное.";
        }

        public string CheckAge(uint age)
        {
            if (age < 12) return "Вы ребёнок";
            else if (12 < age && age < 18) return "Вы подросток";
            else return "Вы взрослый";
        }

        public double Calc(int num1, int num2, char oper)
        {
            double result = 0;
            if (oper == '+') result = num1 + num2;
            else if (oper == '-') result = num1 - num2;
            else if (oper == '*') result = num1 * num2;
            else if (oper == '/')
                if (num1 != 0 || num2 != 0)
                    result = (double)num1 / num2;
                else Console.WriteLine("На ноль делить нельзя!");
            return result;
        }
    }
}
