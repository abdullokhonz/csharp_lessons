using OrderManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Interfaces
{
    public interface IRepository
    {
        void Save(Order order);
    }
}
