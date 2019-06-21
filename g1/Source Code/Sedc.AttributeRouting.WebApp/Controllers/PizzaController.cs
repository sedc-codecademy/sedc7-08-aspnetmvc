using Microsoft.AspNetCore.Mvc;

namespace Sedc.AttributeRouting.WebApp.Controllers
{
    [Route("catalogue/pizzas")]
    public class PizzaController : Controller
    {
        [Route("menu", Name = "menu")]
        public IActionResult Menu()
        {
            return View();
        }

        [Route("offers", Name = "offers")]
        public IActionResult Offers()
        {
            return View();
        }

        [Route("findPizza/{id}", Name = "findPizza")]
        public IActionResult FindPizzaById(int id)
        {
            return View(id);
        }
    }
}