using Microsoft.AspNetCore.Mvc;
using Sedc.PizzApp.WebDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sedc.PizzApp.WebDemo.Controllers
{
    public class PizzaController : Controller
    {
        private static readonly List<Pizza> pizzas = new List<Pizza>
            {
               new Pizza{ Id=1,Name="capri"    },
               new Pizza{ Id=2,Name="tuna"     },
               new Pizza{ Id=3,Name="margarita"},
               new Pizza{ Id=4,Name="pepperoni"},
            };

        public PizzaController()
        {
        }

        public IActionResult Details(int id)
        {
            var pizza = pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        public IActionResult Index()
        {
            //TIPP: how foreach works
            //IEnumerator<string> enumerator = pizzas.GetEnumerator();
            //enumerator.Reset();
            //while (enumerator.MoveNext())
            //{
            //    //do something with the current value;
            //    //enumerator.Current;
            //}

            //ViewData["pizzas"] = pizzas;

            return View(pizzas.ToList());
        }

        //get pizza that is longer than 4 character
        public IActionResult GetPizzaLongerThan4()
        {
            ViewBag.Pizzas = new List<string>
            {
                "capri", "tuna","margarita","pepperoni"
            }.Where(p => p.Length > 4);
            return View("~/Views/Pizza/GetAll.cshtml");
        }
        public IActionResult TestView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            //get the view for creating pizza
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Name)
        {
            //submit the pizza from form
            var newPizza = new Pizza
            {
                Id = pizzas.Max(pizza => pizza.Id) + 1,
                Name = Name
            };
            pizzas.Add(newPizza);

            return RedirectToAction("Details", new
            {
                id = newPizza.Id
            });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pizza = pizzas.First(x => x.Id == id);
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Edit(int Id, string Name)
        {
            var pizza = pizzas.First(x => x.Id == Id);
            pizza.Name = Name;
            return RedirectToAction("Details", new
            {
                id = pizza.Id
            });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var pizza = pizzas.First(x => x.Id == id);
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Delete(int Id, string Name)
        {
            var pizza = pizzas.First(x => x.Id == Id);
            pizzas.Remove(pizza);
            return RedirectToAction("Index");
        }
    }
}
