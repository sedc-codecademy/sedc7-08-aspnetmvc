using System.Collections.Generic;

namespace SEDC.PizzaHut.Domain.Models
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
