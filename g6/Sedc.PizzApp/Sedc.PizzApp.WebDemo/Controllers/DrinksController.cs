using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sedc.PizzApp.WebDemo.Models;

namespace Sedc.PizzApp.WebDemo.Controllers
{
    public class DrinksController : Controller
    {
        private static List<Drink> drinks = new List<Drink>{
            new Drink{ Id = 1 , Name = "CocaCola", Price = 100},
            new Drink{ Id = 2 , Name = "Skopsko", Price = 200},
            new Drink{ Id = 3 , Name = "Wiskey", Price = 300},
            };
        public ActionResult Index()
        {
            return View(drinks);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Drink model)
        {

            return View();
        }

        public ActionResult Edit(int id)
        {

            return View(drinks.FirstOrDefault(d => d.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Drink model)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, Drink model)
        {
            return View();
        }
    }
}