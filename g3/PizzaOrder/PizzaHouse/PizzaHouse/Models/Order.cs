using System;
using System.Collections.Generic;

namespace PizzaHouse.Models
{
    public class Order
    {
        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice
        {
            get
            {
                var totalSum = 0;

                foreach (var item in OrderItems)
                {
                    totalSum += item.Pizza.GetPrice(item.Size) * item.Quantity;
                }

                return totalSum;
            }
        }

        public Order(User user, List<OrderItem> orderItems)
        {
            User = user;
            OrderItems = orderItems;
        }
    }
}
