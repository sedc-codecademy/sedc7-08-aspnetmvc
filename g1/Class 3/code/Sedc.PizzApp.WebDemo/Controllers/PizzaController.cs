using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Sedc.PizzApp.WebDemo.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            //get from database
            //get from api
            var pizzas = new List<string>
            {
                "capri", "tono","margarita", "napolitana"
            };

            return View(pizzas);
            //ViewBag.pizzas = listOfPizzas;
            //ViewData["pizzas"] = listOfPizzas;
            //TempData["pizzas"] = listOfPizzas;
        }

        //public IActionResult GetAll()
        //{
        //    return View("~/Views/Pizza/GetAll.cshtml");
        //}
    }
}
