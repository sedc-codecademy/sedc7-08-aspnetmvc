using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaHouse.Models;
using PizzaHouse.Services;

namespace PizzaHouse.Controllers
{
    //[Route("pizzahouse")]
    public class PizzaController : Controller
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }



        //[Route("menu")]
        public IActionResult Menu()
        {
            Menu menu = _pizzaService.GetMenu();
            return View(menu);
        }
    }
}