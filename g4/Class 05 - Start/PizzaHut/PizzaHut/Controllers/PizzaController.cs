using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaHut.Models;
using PizzaHut.Models.IRepositories;
using PizzaHut.Models.ViewModels;

namespace PizzaHut.Controllers
{
    public class PizzaController : Controller
    {
        //dependency injection
        private IPizzaRepository pizzas;
        public PizzaController(IPizzaRepository repository)
        {
            pizzas = repository;
        }

        public IActionResult Index()
        {
            var model = pizzas.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var pica = pizzas.Get(id);
            return View(pica);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePizzaViewModel model)
        {
            if (ModelState.IsValid)
            {
                Pizza pizza = new Pizza();
                pizza.Name = model.Name;
                pizza.PizzaTypeID = model.PizzaTypeID;
                pizza.Price = model.Price;
                pizza.Size = model.Size;

                pizzas.Add(pizza);
                int count = pizzas.GetAll().Count();
                return RedirectToAction("index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Pizza pizza = pizzas.Get(id);
            if (pizza == null)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel
                {
                    RequestId = id.ToString()
                };
                return View("Error", errorViewModel);                
            }

            EditPizzaViewModel editPizzaViewModel = new EditPizzaViewModel
            {
                ID = pizza.ID,
                Name = pizza.Name,
                PizzaTypeID = pizza.PizzaTypeID,
                Price = pizza.Price,
                Size = pizza.Size
            };
            return View(editPizzaViewModel);

        }

        [HttpPost]
        public IActionResult Edit(EditPizzaViewModel model)
        {
            Pizza pizza = pizzas.Get(model.ID);
            if (ModelState.IsValid)
            {
                pizza.Name = model.Name;
                pizza.PizzaTypeID = model.PizzaTypeID;
                pizza.Price = model.Price;
                pizza.Size = model.Size;

                pizzas.Update(pizza);
                return View("Details",pizza);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = pizzas.Get(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                pizzas.Delete(pizza.ID);
                return RedirectToAction("index");
            }
            return View();
        }

    }
}