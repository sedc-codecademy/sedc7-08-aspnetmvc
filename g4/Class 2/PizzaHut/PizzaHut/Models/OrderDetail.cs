using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models
{
    public class OrderDetail : IEntity
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int PizzaID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
