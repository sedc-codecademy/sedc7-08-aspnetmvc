using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHouse.Models
{
    public class Menu
    {
        public string RestaurantName { get; set; }
        public List<Pizza> PizzasList { get; set; }
        public List<SizeEnum> Sizes { get; set; }

        public Menu(string restaurantName, List<Pizza> pizzasList)
        {
            RestaurantName = restaurantName;
            PizzasList = pizzasList;
            Sizes = new List<SizeEnum> { SizeEnum.Small, SizeEnum.Medium, SizeEnum.Large };
        }
    }
}
