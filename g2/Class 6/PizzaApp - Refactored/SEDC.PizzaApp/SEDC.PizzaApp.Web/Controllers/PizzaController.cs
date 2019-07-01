using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain;
using SEDC.PizzaApp.Services;
using SEDC.PizzaApp.Web.ViewModels;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IService _pizzaService;

        public PizzaController(IService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            List<Pizza> pizzaList = _pizzaService.GetAllPizzas();

            MenuViewModel menu = new MenuViewModel("Pizza House", pizzaList);
            

            return View(menu);
        }
    }
}