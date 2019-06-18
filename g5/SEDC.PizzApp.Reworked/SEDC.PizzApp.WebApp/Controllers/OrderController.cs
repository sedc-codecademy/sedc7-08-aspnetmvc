using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzApp.Domain;
using SEDC.PizzApp.Services.Services;
using SEDC.PizzApp.WebApp.Models;

namespace SEDC.PizzApp.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private IPizzaOrderService _pizzaOrderService;
        public OrderController(IPizzaOrderService pizzaOrderService)
        {
            _pizzaOrderService = pizzaOrderService;
        }
        public IActionResult Index()
        {
            List<Order> orders = _pizzaOrderService.GetAllOrders();
            OrdersViewModel viewModel = new OrdersViewModel()
            {
                Orders = orders
            };
            return View(viewModel);
        }
    }
}