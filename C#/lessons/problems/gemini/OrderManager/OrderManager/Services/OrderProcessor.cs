using OrderManager.Entities;
using OrderManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Services
{
    public class OrderProcessor
    {
        private readonly IRepository _repository;
        private readonly INotificationService _notificationService;

        public OrderProcessor(IRepository repository, INotificationService notificationService)
        {
            _repository = repository;
            _notificationService = notificationService;
        }

        public void Process(Order order)
        {
            // 1. Валидация
            if (order.Items.Count == 0)
            {
                Console.WriteLine("Заказ пуст!");
                return;
            }

            // 2. Логика сохранения в базу данных
            _repository.Save(order);

            // 3. Отправка подтверждения по Email
            _notificationService.SendNotification("Ваш заказ обработан!");
        }
    }
}
