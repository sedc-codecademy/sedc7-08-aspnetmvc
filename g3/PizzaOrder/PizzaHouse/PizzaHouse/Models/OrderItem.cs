using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHouse.Models
{
    public class OrderItem
    {
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; }
        public SizeEnum Size { get; set; }
    }
}
