using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models
{
    public class PizzaType : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
