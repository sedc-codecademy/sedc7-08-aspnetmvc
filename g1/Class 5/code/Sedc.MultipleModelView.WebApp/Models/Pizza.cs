using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.MultipleModelView.WebApp.Models
{
    public class Pizza
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
