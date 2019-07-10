using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzApp.Models;
using PizzApp.Repositories.Abstractions;
using PizzApp.Repositories.AdoNet;
using PizzApp.Repositories.Dapper;
using PizzApp.Repositories.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace Sedc.PizzApp.WebDemo.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaRepository pizzaRepository;

        public PizzaController(IConfiguration configuration)
        {
            //pizzaRepository = new InMemoryPizzaRepository();
            //pizzaRepository = new SqlPizzaRepository(configuration["ConnectionString"]);
            //pizzaRepository = new DapperPizzaRepository(configuration["ConnectionString"]);
            pizzaRepository = new EntityFrameworkPizzaRepository();
        }

        public IActionResult Details(int id)
        {
            var pizza = pizzaRepository.GetById(id);
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

            var pizzas = pizzaRepository.GetAllPizzas();
            return View(pizzas);
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
        public IActionResult Create(Pizza model)
        {
            //submit the pizza from form
            var newPizza = pizzaRepository.Create(model);

            return RedirectToAction("Details", new
            {
                id = newPizza.Id
            });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pizza = pizzaRepository.GetById(id);
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Edit(int Id, Pizza model)
        {
            var pizza = pizzaRepository.Update(model);
            return RedirectToAction("Details", new
            {
                id = pizza.Id
            });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var pizza = pizzaRepository.GetById(id);
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Delete(int Id, Pizza model)
        {
            pizzaRepository.Delete(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddPrice(PizzaPrice pizzaPrice)
        {
            pizzaRepository.AddPrice(pizzaPrice);
            return RedirectToAction("Details", new
            {
                Id = pizzaPrice.PizzaId
            });
        }
    }
}
