using System.Collections.Generic;

namespace SEDC.PizzaHut.Domain.Models
{
    public class PizzaType : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
