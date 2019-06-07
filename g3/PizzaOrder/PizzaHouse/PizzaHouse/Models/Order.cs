using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHouse.Models
{
    public class Order
    {
        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public int TotalPrice
        {
            get
            {
                int totalSum = 0;
                foreach (var item in OrderItems)
                {
                    totalSum += item.Pizza.GetPrice(item.Size) * item.Quantity;
                }
                return totalSum;
            }
        }
    }
}
