using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Interfaces
{
    public interface INotificationService
    {
        void SendNotification(string message);
    }
}
