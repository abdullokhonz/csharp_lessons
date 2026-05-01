using OrderManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Services
{
    public class EmailService : INotificationService
    {
        public void SendNotification(string message)
        {
            Console.WriteLine("Отправка письма: Ваш заказ обработан!");
        }
    }
}
