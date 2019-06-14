using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sedc.FormValidation.WebApp.Models;

namespace Sedc.FormValidation.WebApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult AddPizza()
        {
            return View(new Pizza());
        }

        [HttpPost]
        public IActionResult AddPizza(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = $"Successfully added {pizza.Name}";
                return View(new Pizza());
            }

            return View(pizza);
        }
    }
}