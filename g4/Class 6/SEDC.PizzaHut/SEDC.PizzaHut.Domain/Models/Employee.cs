using System;
using System.Collections.Generic;

namespace SEDC.PizzaHut.Domain.Models
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public DateTime HireDate { get; set; }

        public string City { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}