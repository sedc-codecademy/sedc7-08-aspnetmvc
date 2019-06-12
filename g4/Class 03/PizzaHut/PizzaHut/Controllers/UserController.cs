using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaHut.Models.IRepositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaHut.Controllers
{
    public class UserController : Controller
    {
        //dependency injection
        private IUserRepository users;
        public UserController(IUserRepository repository)
        {
            users = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.TotalCount = users.GetAll().Count();
            ViewData.Add("TotalCount2", users.GetAll().Count());
            ViewData["TotalCount3"] = users.GetAll().Count();
            var model = users.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
