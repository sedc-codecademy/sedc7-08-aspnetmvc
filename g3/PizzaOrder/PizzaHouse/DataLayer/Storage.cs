using System.Collections.Generic;
using DtoModels;

namespace DataLayer
{
    internal static class Storage
    {
        public static List<Ingredient> Ingredients = new List<Ingredient>
        {
            new Ingredient(1,"ham", new List<string>()),
            new Ingredient(2,"cheese", new List<string>{"milk"}),
            new Ingredient(3,"mushrooms", new List<string>()),
            new Ingredient(4, "pepperoni", new List<string>()),
        };

        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza(1, "Capri", "The best capri pizza in town!", new List<Ingredient>
            {
                Ingredients[0],
                Ingredients[1],
                Ingredients[2]
            }, 160),
            new Pizza(2, "Pepperoni", "Pizza with homemade pepperoni sausage!", new List<Ingredient>()
            {
                Ingredients[1],
                Ingredients[2],
                Ingredients[3]
            }, 160)
        };

        public static List<User> Users = new List<User>()
        {
            new User(1, "Risto", "Skopje", "12234445")
        };
    }
}
