using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHouse.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public List<string> Allergens { get; set; }

        public Ingredient(string name, List<string> allergens)
        {
            Name = name;
            Allergens = allergens;
        }
    }
}
