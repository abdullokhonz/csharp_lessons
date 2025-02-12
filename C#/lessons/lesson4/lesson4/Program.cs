using System;

namespace lesson4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*string name = Console.ReadLine() ;
            switch (name)
            {
                case "Tom":
                    Console.WriteLine("Hello " + name);
                    goto case "Martin";
                case "Bob":
                    Console.WriteLine("Hello " + name);
                    break;
                case "Martin":
                    Console.WriteLine("Hello " + name);
                    break;
                default:
                    Console.WriteLine("Idk ur name");
                    break;
            }*/

            /*int DoOperation(int op, int a, int b)
            {
                switch (op)
                {
                    case 1: return a + b;
                    case 2: return a - b;
                    case 3: return a * b;
                    default: return 0;
                }
            }
            int num = DoOperation(1, 2, 3);
            Console.WriteLine(num);*/

            // Ex - 1
            /*int day = Convert.ToInt32(Console.ReadLine());
            string result = day switch
            {
                1 => "Понедельник",
                2 => "Вторник",
                3 => "Среда",
                4 => "Четверг",
                5 => "Пятница",
                6 => "Суббота",
                7 => "Воскресенье",
                _ => "Неизвестный день недели!",
            };
            Console.WriteLine(result);*/

            // Ex - 2
            /*int k = Convert.ToInt32(Console.ReadLine());
            string result = k switch
            {
                1 => "Плохо",
                2 => "Неудовлетворительно",
                3 => "Удовлетворительно",
                4 => "Хорошо",
                5 => "Отлично",
                _ => "Ошибка!",
            };
            Console.WriteLine(result);*/

            // Ex - 3
            /*int month = Convert.ToInt32(Console.ReadLine());
            string result = month switch
            {
                1 => "Зима - Январь",
                2 => "Зима - Февраль",
                3 => "Весна - Мрарт",
                4 => "Весна - Апрель",
                5 => "Весна - Май",
                6 => "Лето - Июнь",
                7 => "Лето - Июль",
                8 => "Лето - Август",
                9 => "Осеь - Сентябрь",
                10 => "Осеь - Октябрь",
                11 => "Осеь - Ноябрь",
                12 => "Зима - Декабрь",
                _ => "Ошибка!",
            };
            Console.WriteLine(result);*/

            // Ex - 4
            /*Console.Write("Enter first number: ");
            int firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int secondNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter math operation: ");
            uint oper = Convert.ToUInt32(Console.ReadLine());

            if (secondNumber == 0) Console.WriteLine("not allow");
            string result = oper switch
            {
                1 => Convert.ToString(firstNumber + secondNumber),
                2 => Convert.ToString(firstNumber - secondNumber),
                3 => Convert.ToString(firstNumber * secondNumber),
                4 => Convert.ToString(firstNumber / secondNumber),
                _ => "Ошибка"
            };
            Console.WriteLine(result);*/
        }
    }
    /*enum Days
    {
        sunday,
        monday,
        tuesday,
        thirthday,
    }*/
}
