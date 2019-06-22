using SEDC.EntityFrameworkPizza.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.EntityFrameworkPizza.Models
{
    public class HomeViewModel
    {
        public List<Pizza> Pizzas { get; set; }
        public List<Order> Orders { get; set; }
    }
}
