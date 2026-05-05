using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var service = new BookingService();

            // Тест 1: Успешное бронирование
            service.BookTable(1, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2));

            // Тест 2: Попытка забронировать то же время (пересечение)
            service.BookTable(1, DateTime.Now.AddHours(1.5), DateTime.Now.AddHours(2.5));

            // Тест 3: Слишком длинная бронь
            service.BookTable(2, DateTime.Now.AddHours(1), DateTime.Now.AddHours(6));
        }
    }
}
