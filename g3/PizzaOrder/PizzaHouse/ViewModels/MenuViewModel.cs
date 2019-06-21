using System.Collections.Generic;

namespace ViewModels
{
    public class MenuViewModel
    {
        public string RestaurantName { get; set; }
        public List<PizzaViewModel> PizzasList { get; set; }
        public List<SizeEnum> Sizes { get; set; }

        public MenuViewModel(string restaurantName, List<PizzaViewModel> pizzasList)
        {
            RestaurantName = restaurantName;
            PizzasList = pizzasList;
            Sizes = new List<SizeEnum> { SizeEnum.Small, SizeEnum.Medium, SizeEnum.Large };
        }
    }
}
