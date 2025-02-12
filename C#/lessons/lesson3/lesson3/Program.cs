using System;

namespace lesson3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int a = 1;
            for (float i = 0; i < a; i+=0.1f)
            {
                Console.WriteLine(i);
            }*/

            /*int[] a = { 1, 2, 3, 4 };
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }*/

            // Ex - 1
            /*Console.Write("Enter number K: ");
            int k = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number N: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(k);
            }*/

            // Ex - 2
            /*  Console.Write("Enter number A: ");
              int a = Convert.ToInt32(Console.ReadLine());

              Console.Write("Enter number B: ");
              int b = Convert.ToInt32(Console.ReadLine());

              for (int i = a; i <= b; i++)
              {
                  Console.WriteLine(i);
              }
              Console.WriteLine("Count of these numbers: " + b);
  */
            // Ex - 3
            /*Console.Write("Enter number A: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number B: ");
            int b = Convert.ToInt32(Console.ReadLine());

            for (int i = b; i >= a; i--)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Count of these numbers: " + b);*/

            // Ex - 4
            /*int a = 0;
            for (int i = 1; i <= 5; i++)
            {
                a += i;
            }
            Console.WriteLine(a);*/

            // Ex - 5
            /*Console.Write("Enter password: ");
            string password = Console.ReadLine();

            while (password != "1234")
            {
                Console.Write("Enter password: ");
                password = Console.ReadLine();
            }
            Console.WriteLine("Yes");*/

            // Ex - 6
            /*for (int i = 2; i <= 10; i += 2)
            {
                Console.WriteLine(i);
            }*/

            // Ex - 7
            /*Console.Write("Enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            uint chet = 0, nechet = 0;
            for (int i = 1; i <= num; i++)
            {
                if (i % 2 == 0) chet++;
                else nechet++;
            }
            Console.WriteLine($"Количество чётных чисел до {num}: {chet}");
            Console.WriteLine($"Количество нечётных чисел до {num}: {nechet}");*/

            // Ex - 8
            /*int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int i in nums) Console.WriteLine(i);
            Console.WriteLine("Сумма всех чисел массива: " + nums.Sum());*/
        }
    }
}
