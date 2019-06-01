using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.App.Models.DomainModels;

namespace SEDC.App.Controllers
{
    public class OrderController : Controller
    {
        private List<Order> _ordersDb;
        public OrderController()
        {
            User bob = new User()
            {
                FirstName = "Bob",
                LastName = "Bobsky",
                Address = "Bob Street",
                Phone = 080012312345
            };
            User jill = new User()
            {
                FirstName = "Jill",
                LastName = "Wayne",
                Address = "Jill Street",
                Phone = 08006546345
            };
            _ordersDb = new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    User = bob,
                    Pizza = "Kapri",
                    Price = 10.5
                },
                new Order()
                {
                    Id = 2,
                    User = bob,
                    Pizza = "Toskana",
                    Price = 13
                },
                new Order()
                {
                    Id = 3,
                    User = jill,
                    Pizza = "Peperoni",
                    Price = 11.5
                }
            };
        }
        [Route("Orders")]
        public IActionResult Index()
        {
            //ViewData.Add("Title", "Welcome to the Orders page!");
            ViewBag.Title = "Welcome to the Orders page!";
            return View();
        }
        public IActionResult Details(int? id)
        {
            //ViewData.Add("Title", "These are your orders:");
            //ViewData["Title"] = "These are your orders:";
            Order order = _ordersDb[0];
            ViewBag.Title = $"This is order no. {order.Id}";
            if (id == order.Id) return View(order);
            return RedirectToAction("Index", "Home");
        }
    }
}