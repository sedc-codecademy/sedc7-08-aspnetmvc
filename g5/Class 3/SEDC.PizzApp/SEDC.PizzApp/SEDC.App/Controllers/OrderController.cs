using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.App.Models.DomainModels;
using SEDC.App.Models.ViewModels;

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
            Order firstOrder = _ordersDb[0];
            OrdersViewModel ordersViewModel = new OrdersViewModel()
            {
                FirstPizza = firstOrder.Pizza,
                NumberOfOrders = _ordersDb.Count,
                FirstPersonName = $"{firstOrder.User.FirstName} {firstOrder.User.LastName}"
            };
            return View(ordersViewModel);
        }
        public IActionResult Details(int? id)
        {
            #region ViewBag and ViewData
            //ViewData.Add("Title", "These are your orders:");
            //ViewData["Title"] = "These are your orders:";
            #endregion
            #region FirstOrDefault solution
            Order order = _ordersDb.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                ViewBag.Title = $"This is order no. {order.Id}";
                return View(order);
            }
            return RedirectToAction("Index");
            #endregion
            #region try/catch solution
            //try
            //{
            //    Order order = _ordersDb.Find(x => x.Id == id);
            //    ViewBag.Title = $"This is order no. {order.Id}";
            //    if (order != null) return View(order);
            //}
            //catch
            //{
            //    return RedirectToAction("Index");
            //}
            //return RedirectToAction("Index");
            #endregion
            #region Redirecting to a different controller
            //return RedirectToAction("Index", "Home");
            #endregion
        }
    }
}