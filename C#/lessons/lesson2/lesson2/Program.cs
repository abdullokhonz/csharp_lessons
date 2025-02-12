namespace lesson2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            string name = "Abdullo";
            int age = 16;
            float height = 1.8f;
            Console.WriteLine($"Name: {2}\nAge: {1}\nHeight: {0}m", height, age, name);
            */

            /*
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Your age: {age} years old");
            */

            /*
            int a = 5;
            if (a != 5)
            {
                a++;
                Console.WriteLine(a);
            }
            else if (a == 0)
            {
                Console.WriteLine("idk");
            }
            else
            {
                Console.WriteLine("A не больше пяти");
            }
            */

            /*
            // Ex - 1
            Console.Write("Enter some number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            
            if (num > 0)
            {
                Console.WriteLine("Число положительное");
            }
            else if (num < 0)
            {
                Console.WriteLine("Число отрицательное");
            }
            else
            {
                Console.WriteLine("Это ноль");
            }
            */

            /*
            // Ex - 2
            Console.Write("Enter some number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num % 2 == 0)
            {
                Console.WriteLine("Число чётное");
            }
            else
            {
                Console.WriteLine("Число нечётное");
            }
            */

            // Ex - 3
            /*Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            if (age < 12)
            {
                Console.WriteLine("Вы ребёнок");
            }
            else if (age >= 12 && age < 18)
            {
                Console.WriteLine("Вы подросток");
            }
            else
            {
                Console.WriteLine("Вы взрослый");
            }*/


            /*
            // Ex - 4
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter math operation : ");
            string oper = Console.ReadLine();

            if (oper == "+")
            {
                Console.WriteLine(num1 + oper + num2 + "=" + (num1 + num2));
            }
            else if (oper == "-")
            {
                Console.WriteLine(num1 + oper + num2 + "=" + (num1 - num2));
            }
            else if (oper == "*")
            {
                Console.WriteLine(num1 + oper + num2 + "=" + (num1 * num2));
            }
            else if (oper == "/")
            {
                if (num1 == 0 || num2 == 0)
                {
                    Console.WriteLine("На ноль делить нельзя!");
                }
                else
                {
                    Console.WriteLine(num1 + oper + num2 + "=" + (num1 / num2));
                }
            }
            */

            // Ex - 5
            /*Console.Write("Enter some year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                Console.WriteLine("Год высокосный");
            }
            else
            {
                Console.WriteLine("Год не высокосный");
            }*/

            // homework

            // Ex - 1
            /*Console.Write("Введите длину первого отрезка: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите длину второго отрезка: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите длину третьего отрезка: ");
            int c = Convert.ToInt32(Console.ReadLine());

            if (a + b > c && a + c > b && b + c > a)
            {
                Console.WriteLine("Да!");
            }
            else
            {
                Console.WriteLine("Нет!");
            }*/

            // Ex - 2
            /*Console.Write("Введите первое число: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int b = Convert.ToInt32(Console.ReadLine());

            if (a != b)
            {
                if (a >= b)
                {
                    b = a;
                }
                else
                {
                    a = b;
                }
            }
            else
            {
                a = 0; b = 0;
            }

            Console.WriteLine($"A = {a}; B = {b};");*/

            // Ex - 3
            /*Console.Write("Введите первое число: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите третье число: ");
            int c = Convert.ToInt32(Console.ReadLine());

            if (a < b && a < c)
            {
                Console.WriteLine("Наименьшее число: " + a);
            }
            else if (b < a  && b < c)
            {
                Console.WriteLine("Наименьшее число: " + b);
            }
            else
            {
                Console.WriteLine("Наименьшее число: " + c);
            }*/

            // Ex - 4
            /*Console.Write("Введите первое число: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите третье число: ");
            int c = Convert.ToInt32(Console.ReadLine());

            int max1, max2;

            if (a >= b && a >= c)
            {
                max1 = a;
                max2 = (b > c) ? b : c;
            }
            else if (b >= a && b >= c)
            {
                max1 = b;
                max2 = (a > c) ? a : c;
            }
            else
            {
                max1 = c;
                max2 = (a > b) ? a : b;
            }

            Console.WriteLine($"Сумма двух наибольших чисел: {max1 + max2}");*/


            // Ex - 5
            /*Console.Write("Введите первое число: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите второе число: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите третье число: ");
            int c = Convert.ToInt32(Console.ReadLine());

            if (a == b)
            {
                Console.WriteLine("Третье число отличается от двух одинаковых");
            }
            else if (a == c)
            {
                Console.WriteLine("Второе число отличается от двух одинаковых");
            }
            else
            {
                Console.WriteLine("Первое число отличается от двух одинаковых");
            }*/
        }
    }
}
