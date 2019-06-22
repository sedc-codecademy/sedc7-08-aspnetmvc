using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.EntityFrameworkPizza.DataAccess;
using SEDC.EntityFrameworkPizza.DataAccess.Domain;
using SEDC.EntityFrameworkPizza.Models;

namespace SEDC.EntityFrameworkPizza.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Pizza> _pizzaRepository;
        public HomeController(IRepository<Order> orderRepository,
            IRepository<Pizza> pizzaRepository)
        {
            _orderRepository = orderRepository;
            _pizzaRepository = pizzaRepository;
        }
        public IActionResult Index()
        {
            List<Order> orders = _orderRepository.GetAll();
            List<Pizza> pizzas = _pizzaRepository.GetAll();
            foreach (Order order in orders)
            {
                order.Pizzas = pizzas.Where(x => x.OrderId == order.Id).ToList();
            }
            HomeViewModel model = new HomeViewModel();
            model.Orders = orders;
            model.Pizzas = pizzas
                .GroupBy(x => x.Name)
                .Select(x => x.First())
                .ToList();
            return View(model);
        }
        public IActionResult Pizza(int? id)
        {
            PizzaViewModel model = new PizzaViewModel();
            model.Pizza = new Pizza() { OrderId = id.Value };
            return View(model);
        }
        [HttpPost]
        public IActionResult Pizza(PizzaViewModel model)
        {
            _pizzaRepository.Insert(model.Pizza);
            return RedirectToAction("Index");
        }
    }
}
