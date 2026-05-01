using OrderManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Services
{
    public class OldOrderProcessor
    {
        public void Process(Order order)
        {
            // 1. Валидация
            if (order.Items.Count == 0)
            {
                Console.WriteLine("Заказ пуст!");
                return;
            }

            // 2. Логика сохранения в базу данных
            Console.WriteLine($"Сохранение заказа {order.Id} в базу данных SQL Server...");

            // 3. Отправка подтверждения по Email
            Console.WriteLine("Отправка письма: Ваш заказ обработан!");
        }
    }
}
