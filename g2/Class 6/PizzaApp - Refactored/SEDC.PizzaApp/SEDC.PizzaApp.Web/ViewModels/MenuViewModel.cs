using SEDC.PizzaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Web.ViewModels
{
    public class MenuViewModel
    {
        public string RestaurantName { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public List<PizzaSize> Sizes { get; set; }

        public MenuViewModel(string restaurantName, List<Pizza> pizzasList)
        {
            RestaurantName = restaurantName;
            Pizzas = pizzasList;
            Sizes = new List<PizzaSize> { PizzaSize.Small, PizzaSize.Medium, PizzaSize.Large };
        }
    }
}
