using System.Collections.Generic;

namespace PizzaHouse.Models
{
    public class Menu
    {
        public string RestaurantName { get; set; }
        public List<Pizza> PizzaList { get; set; }
        public List<SizeEnum> Sizes { get; set; }

        public Menu(string restaurantName, List<Pizza> pizzaList)
        {
            RestaurantName = restaurantName;
            PizzaList = pizzaList;
            Sizes = new List<SizeEnum> { SizeEnum.Small, SizeEnum.Medium, SizeEnum.Large};
        }
    }
}
