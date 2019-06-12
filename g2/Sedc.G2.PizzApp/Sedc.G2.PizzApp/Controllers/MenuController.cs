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
        //static list that is used to simulate database, with predefined data
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
            //sending the pizza list to the Index view
            return View(pizzaList);
        }

        public IActionResult PizzaDetails(int id)
        {
            //get the requested pizza from the pizza list using linq
            var pizza = pizzaList.FirstOrDefault(x => x.Id == id);
            //send the found pizza to PizzaDetails view
            return View(pizza);
        }

        public IActionResult Edit(int id)
        {
            //get the requested pizza from the pizza list using linq
            var pizza = pizzaList.FirstOrDefault(x => x.Id == id);
            //send the found pizza to Edit view
            return View(pizza);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PizzaModel model)
        {
            //on save check if the model that is sent for saving is valid
            //if not then return to Add view and display the validation messages
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Add the model to pizzaList
            pizzaList.Add(model);

            //redirect to Menu Index view and pass the updated pizzaList
            //this should display all pizzas including the new added one
            return View("Index", pizzaList);
        }

        [HttpPost]
        //Added custom routing on save on pizza edit view
        //Also added aditional routing in Startup.cs
        [Route("UpdatePizza")]
        public IActionResult SaveChanges(PizzaModel model)
        {
            //on save check if the model that is sent for saving is valid
            //if not then return to Edit view and display the validation messages
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            //find the index of the view that shoud be updated
            var index = pizzaList.FindIndex(x => x.Id == model.Id);
            //update the found pizza model with the new updated model
            pizzaList[index] = model;
            //redirect to Menu Index view and pass the updated pizzaList
            //this should display all pizzas
            return View("Index", pizzaList);
        }

        public IActionResult Delete(int id)
        {
            var pizza = pizzaList.FirstOrDefault(x => x.Id == id);
            pizzaList.Remove(pizza);
            return View("Index", pizzaList);
        }
    }
}