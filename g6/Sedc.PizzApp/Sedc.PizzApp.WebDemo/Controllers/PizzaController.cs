using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Sedc.PizzApp.WebDemo.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult GetAll()
        {
            ViewBag.Pizzas = new List<string>
            {
                "capri", "tuna","margarita","pepperoni"
            };
            return View();
        }
    }
}
