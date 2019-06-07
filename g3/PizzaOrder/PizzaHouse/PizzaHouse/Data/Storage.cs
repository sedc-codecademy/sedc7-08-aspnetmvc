using PizzaHouse.Models;
using System.Collections.Generic;

namespace PizzaHouse.Data
{
    internal static class Storage
    {
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza("Capri", "The best capri pizza in town!", new List<Ingredient>()
            {
                new Ingredient("ham", new List<string>()),
                new Ingredient("cheese", new List<string>{"milk"}),
                new Ingredient("mushrooms", new List<string>())
            }, 160),
            new Pizza("Pepperoni", "Pizza with homemade pepperoni sausage!", new List<Ingredient>()
            {
                new Ingredient("pepperoni", new List<string>()),
                new Ingredient("cheese", new List<string>{"milk"}),
                new Ingredient("mushrooms", new List<string>())
            }, 160)
        };

        public static Menu RestaurantMenu = new Menu("Pizza House", Pizzas);
    }
}
