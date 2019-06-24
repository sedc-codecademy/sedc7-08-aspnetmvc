using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models
{
    public class Pizza : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PizzaTypeID { get; set; }
        public SizeEnum Size { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual PizzaType PizzaType { get; set; }
    }
}
