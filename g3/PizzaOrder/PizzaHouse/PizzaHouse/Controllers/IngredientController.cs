using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace PizzaHouse.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public IActionResult ListAllIngredients()
        {
            var allIngredients = _ingredientService.GetAllIngredients();
            return View(allIngredients);
        }
    }
}