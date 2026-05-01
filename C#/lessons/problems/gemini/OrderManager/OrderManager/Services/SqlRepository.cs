using OrderManager.Entities;
using OrderManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Services
{
    public class SqlRepository : IRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine($"Сохранение заказа {order.Id} в базу данных SQL Server...");
        }
    }
}
