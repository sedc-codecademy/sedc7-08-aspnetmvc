using System;
using System.Collections.Generic;
using System.Linq;
using PizzaHouse.Data;
using PizzaHouse.Models;
using PizzaHouse.ViewModels;

namespace PizzaHouse.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public Menu GetMenu()
        {
            return _pizzaRepository.GetMenu();
        }

        public void CreatePizza(PizzaViewModel pizza)
        {
            var nextId = Storage.Pizzas.Last().Id + 1;

            var ingredients = new List<Ingredient>();
            foreach (var selectedIngredient in pizza.SelectedIngredients)
            {
                var ingredient = Storage.Ingredients.FirstOrDefault(x => x.Id == selectedIngredient);

                if (ingredient == null)
                {
                    throw new Exception($"Ingredient with Id {selectedIngredient} does not exist");
                }

                ingredients.Add(ingredient);
            }

            var pizzaModel = new Pizza(nextId, pizza.Name, pizza.Description, ingredients, pizza.BasePrice);

            _pizzaRepository.Create(pizzaModel);
        }
    }
}
