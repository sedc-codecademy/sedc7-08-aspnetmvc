using SEDC.PizzaHut.Domain.Enums;
using System.Collections.Generic;

namespace SEDC.PizzaHut.Domain.Models
{
    public class Pizza : Entity
    {
        public string Name { get; set; }

        public int PizzaTypeId { get; set; }

        public SizeEnum Size { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual PizzaType PizzaType { get; set; }
    }
}
