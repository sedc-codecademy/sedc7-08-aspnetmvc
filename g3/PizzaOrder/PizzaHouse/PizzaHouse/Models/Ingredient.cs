using System.Collections.Generic;

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
