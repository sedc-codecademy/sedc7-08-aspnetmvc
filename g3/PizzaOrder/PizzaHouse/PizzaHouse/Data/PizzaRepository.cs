using System;
using PizzaHouse.Models;

namespace PizzaHouse.Data
{
    public class PizzaRepository : IPizzaRepository
    {
        public Menu GetMenu()
        {
            return Storage.RestaurantMenu;
        }
    }
}
