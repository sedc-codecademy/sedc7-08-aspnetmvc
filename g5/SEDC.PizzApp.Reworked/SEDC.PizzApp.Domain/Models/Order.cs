using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzApp.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public double Price
        {
            get
            {
                return Pizzas.Sum(x => x.Price) + 2;
            }
        }
    }
}
