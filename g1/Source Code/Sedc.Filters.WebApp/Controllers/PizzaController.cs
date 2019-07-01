using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sedc.Filters.WebApp.Models;

namespace Sedc.Filters.WebApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult AddPizza()
        {
            return View(new Pizza());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPizza(Pizza pizza)
        {
            ViewBag.Message = $"Successfully added {pizza.Name}";

            return View(new Pizza());
        }

        public IActionResult EditPizza()
        {
            return View(new Pizza
            {
                Name = "Carbonara", Description = "Very tasty pizza!", Style = "New York Style",
                Ingredients = "Cream Sauce, 100% Mozzarella, Parmesan, Bacon, Mushrooms", Allergens = "Gluten, Lactose",
                IsVegan = false, IsFasting = false, IsHalal = false, IsKosher = false, Price = 400.0
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPizza(Pizza pizza)
        {
            ViewBag.Message = $"Successfully edited {pizza.Name}";

            return View(new Pizza());
        }
    }
}