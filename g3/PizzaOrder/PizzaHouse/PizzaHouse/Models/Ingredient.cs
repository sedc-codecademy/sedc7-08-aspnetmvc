using System.Collections.Generic;

namespace PizzaHouse.Models
{
    public class Ingredient : IEntity
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
