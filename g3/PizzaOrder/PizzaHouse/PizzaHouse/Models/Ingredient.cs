using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHouse.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Allergens { get; set; }

        public Ingredient(int id, string name, List<string> allergens)
        {
            Id = id;
            Name = name;
            Allergens = allergens;
        }
    }
}
