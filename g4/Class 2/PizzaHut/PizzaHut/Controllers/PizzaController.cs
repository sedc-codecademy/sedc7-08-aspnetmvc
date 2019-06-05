using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaHut.Models;

namespace PizzaHut.Controllers
{
    public class PizzaController : Controller
    {
        List<Pizza> pizzas;
        public PizzaController()
        {
            pizzas = new List<Pizza>()
            {
                new Pizza{ID=1, Name="Caprichiosa",PizzaTypeID=1, Size=SizeEnum.Small,Price=150},
                new Pizza{ID=2, Name="Quatro stagone",PizzaTypeID=2, Size=SizeEnum.Medium,Price=200},
                new Pizza{ID=3, Name="Vegetariana",PizzaTypeID=3, Size=SizeEnum.Large,Price=250},
            };
        }
        public IActionResult Index()
        {
            var model = pizzas;
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var pica = pizzas.FirstOrDefault(p => p.ID == id);
            return View(pica);
        }

    }
}