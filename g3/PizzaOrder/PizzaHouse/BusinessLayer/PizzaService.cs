using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DtoModels;
using Mappers;
using ViewModels;

namespace BusinessLayer
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<Pizza> _pizzaRepository;
        private readonly IRepository<Ingredient> _ingredientRepository;
        private readonly IIngredientService _ingredientService;

        public PizzaService(IRepository<Pizza> pizzaRepository,
        IRepository<Ingredient> ingredientRepository,
        IIngredientService ingredientService)
        {
            _pizzaRepository = pizzaRepository;
            _ingredientRepository = ingredientRepository;
            _ingredientService = ingredientService;
        }

        public MenuViewModel GetMenu()
        {
            return new MenuViewModel("Pizza Restaurant",
                _pizzaRepository.GetAll().Select(x => x.ToViewModel()).ToList());
        }

        public void CreatePizza(CreatePizzaViewModel pizza)
        {
            var lastPizza = _pizzaRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault();
            var nextId = lastPizza?.Id + 1 ?? 1;

            var ingredients = new List<Ingredient>();
            foreach (var selectedIngredient in pizza.SelectedIngredients)
            {
                var ingredient = _ingredientRepository.GetById(selectedIngredient);

                if (ingredient == null)
                {
                    throw new Exception($"Ingredient with Id {selectedIngredient} does not exist");
                }

                ingredients.Add(ingredient);
            }

            var pizzaModel = new Pizza(nextId, pizza.Name, pizza.Description, ingredients, pizza.BasePrice);

            _pizzaRepository.Create(pizzaModel);
        }

        public PizzaViewModel GetPizza(int id)
        {
            return _pizzaRepository.GetById(id).ToViewModel();
        }

        public CreatePizzaViewModel GetEmptyPizza()
        {
            var pizza = new Pizza();
            var createPizzaViewModel = pizza.ToCreateModel();
            createPizzaViewModel.AllIngredients = _ingredientService.GetIngredientsSelectList();
            return createPizzaViewModel;
        }

        public CreatePizzaViewModel GetPizzaUpdateModel(int id)
        {
            var pizza = _pizzaRepository.GetById(id);
            var updatePizzaViewModel = pizza.ToCreateModel();
            updatePizzaViewModel.AllIngredients = _ingredientService.GetIngredientsSelectList();
            return updatePizzaViewModel;
        }

        public void UpdatePizza(CreatePizzaViewModel pizza)
        {
            var ingredients = new List<Ingredient>();
            foreach (var selectedIngredient in pizza.SelectedIngredients)
            {
                var ingredient = _ingredientRepository.GetById(selectedIngredient);

                if (ingredient == null)
                {
                    throw new Exception($"Ingredient with Id {selectedIngredient} does not exist");
                }

                ingredients.Add(ingredient);
            }

            var pizzaModel = new Pizza(pizza.Id, pizza.Name, pizza.Description, ingredients, pizza.BasePrice);

            _pizzaRepository.Update(pizzaModel);
        }
    }
}
