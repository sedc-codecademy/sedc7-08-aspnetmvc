using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sedc.G2.PizzApp.Models;

namespace Sedc.G2.PizzApp.Controllers
{
    public class MenuController : Controller
    {
        private static List<PizzaModel> pizzaList = new List<PizzaModel>
        {
            new PizzaModel
            {
                Id = 1,
                Name = "Capricioza",
                Description = "Some description",
                Size = "small",
                Price = 140
            },
            new PizzaModel
            {
                Id = 2,
                Name = "Capricioza",
                Description = "Some description",
                Size = "medium",
                Price = 200
            },
            new PizzaModel
            {
                Id = 3,
                Name = "Capricioza",
                Description = "Some description",
                Size = "large",
                Price = 240
            },
            new PizzaModel
            {
                Id = 4,
                Name = "Capricioza",
                Description = "Some description",
                Size = "family",
                Price = 350
            }
        };
        public IActionResult Index()
        {
            return View(pizzaList);
        }

        public IActionResult PizzaDetails(int id)
        {
            var pizza = pizzaList.FirstOrDefault(x => x.Id == id);
            return View(pizza);
        }
    }
}