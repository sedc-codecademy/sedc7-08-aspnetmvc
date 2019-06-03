using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        //get pizza that is longer than 4 character
        public IActionResult GetPizzaLongerThan4()
        {
            ViewBag.Pizzas = new List<string>
            {
                "capri", "tuna","margarita","pepperoni"
            }.Where(p=>p.Length > 4);
            return View("~/Views/Pizza/GetAll.cshtml");
        }


        public IActionResult TestView()
        {
            return View();
        }
    }
}
