using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sedc.ConventionalRouting.WebApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult Offers()
        {
            return View();
        }

        public IActionResult FindPizzaById(int id)
        {
            return View(id);
        }
    }
}