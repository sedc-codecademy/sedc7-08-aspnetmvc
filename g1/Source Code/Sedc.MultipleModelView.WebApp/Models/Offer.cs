using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.MultipleModelView.WebApp.Models
{
    public class Offer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}
