using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.App.Models.DomainModels;
using SEDC.App.Models.Enums;
using SEDC.App.Models.ViewModels;

namespace SEDC.App.Controllers
{
    public class OrderController : Controller
    {
        [Route("Orders")]
        public IActionResult Index()
        {
            //ViewData.Add("Title", "Welcome to the Orders page!");
            ViewBag.Title = "Welcome to the Orders page!";
            Order firstOrder = Db.Orders[0];
            OrdersViewModel ordersViewModel = new OrdersViewModel()
            {
                FirstPizza = firstOrder.Pizza.Name,
                NumberOfOrders = Db.Orders.Count,
                FirstPersonName = $"{firstOrder.User.FirstName} {firstOrder.User.LastName}",
                Orders = Db.Orders
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
            Order order = Db.Orders.FirstOrDefault(x => x.Id == id);
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
        [HttpGet("Order")]
        public IActionResult Order(string error)
        {
            ViewBag.Error = error == null ? "" : error;
            OrderViewModel model = new OrderViewModel();
            return View(model);
        }

        [HttpPost("Order")]
        public IActionResult Order(OrderViewModel model)
        {
            // We check if the pizza exists in the menu
            Pizza pizza = Db.Menu.FirstOrDefault(x =>
            x.Name == model.Pizza && x.Size == model.Size);
            // If it does not exist ( null is default for object ) then return to Order view
            if (pizza == null) return RedirectToAction("Order", new { error = "There is no pizza like that in the menu!"});
            Db.UserId++;
            User user = new User()
            {
                Id = Db.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Phone = model.Phone
            };
            Db.OrderId++;
            Order order = new Order()
            {
                Id = Db.OrderId,
                Delivered = false,
                Pizza = pizza,
                Price = pizza.Price + 2,
                User = user
            };
            Db.Orders.Add(order);
            Db.Users.Add(user);
            return View("_ThankYou");
        }
    }
}