using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public List<string> Items { get; set; } = new List<string>();
        public decimal TotalAmount { get; set; }
    }
}
