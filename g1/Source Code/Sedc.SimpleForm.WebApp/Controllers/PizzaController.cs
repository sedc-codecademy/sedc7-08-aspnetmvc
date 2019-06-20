using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sedc.SimpleForm.WebApp.Models;

namespace Sedc.SimpleForm.WebApp.Controllers
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
            ViewBag.Message = $"Successfully added {pizza.Name}";

            return View(new Pizza());
        }
    }
}