using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace PizzaHouse.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;
        private readonly IIngredientService _ingredientService;
        public PizzaController(IPizzaService pizzaService,
            IIngredientService ingredientService)
        {
            _pizzaService = pizzaService;
            _ingredientService = ingredientService;
        }

        public IActionResult Menu()
        {
            MenuViewModel menu = _pizzaService.GetMenu();
            return View(menu);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var pizza = _pizzaService.GetEmptyPizza();
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Create(CreatePizzaViewModel pizza)
        {
            if (!ModelState.IsValid)
            {
                pizza.AllIngredients = _ingredientService.GetIngredientsSelectList();
                return View(pizza);
            }

            if (pizza.Id == 0)
            {
                _pizzaService.CreatePizza(pizza);
            }
            else
            {
                _pizzaService.UpdatePizza(pizza);
            }

            return RedirectToAction("Menu", "Pizza");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var pizza = _pizzaService.GetPizza(id);
            return View(pizza);
        }
        

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pizza = _pizzaService.GetPizzaUpdateModel(id);
            return View("Create", pizza);
        }
    }
}