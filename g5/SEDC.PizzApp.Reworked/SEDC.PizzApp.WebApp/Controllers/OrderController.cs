﻿using System;
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
        private IUserService _userService;
        public OrderController(IPizzaOrderService pizzaOrderService, IUserService userService)
        {
            _pizzaOrderService = pizzaOrderService;
            _userService = userService;
        }
        [Route("Orders")]
        public IActionResult Index()
        {
            List<Order> orders = _pizzaOrderService.GetAllOrders();
            List<OrderItemViewModel> viewOrders = new List<OrderItemViewModel>();
            foreach (Order order in orders)
            {
                List<PizzaViewModel> pizzasView = new List<PizzaViewModel>();
                foreach (var pizza in order.Pizzas)
                {
                    pizzasView.Add(new PizzaViewModel()
                    {
                        Id = pizza.Id,
                        Image = pizza.Image,
                        Name = pizza.Name,
                        Price = pizza.Price,
                        Size = pizza.Size
                    });
                };
                viewOrders.Add(new OrderItemViewModel()
                {
                    FirstName = order.User.FirstName,
                    LastName = order.User.LastName,
                    Id = order.Id,
                    Price = order.Price,
                    Pizzas = pizzasView
                });
            }
            OrdersViewModel model = new OrdersViewModel()
            {
                LastPizza = _pizzaOrderService.GetLastOrder().Pizzas[0].Name,
                MostPopularPizza = _pizzaOrderService.GetMostPopularPizza(),
                NameOfFirstCustomer = _userService.GetLastUserName(),
                OrderCount = _pizzaOrderService.GetOrderCount(),
                Orders = viewOrders
            };
            return View(model);
        }
        [HttpGet("Order")]
        public IActionResult Order(string error, int? pizzas)
        {
            if (error != null) return View("_Error");

            OrderViewModel viewModel = new OrderViewModel();
            viewModel.Pizzas = new List<PizzaViewModel>();
            for (int i = 0; i < pizzas.Value; i++)
            {
                viewModel.Pizzas.Add(new PizzaViewModel());
            }

            return View(viewModel);
        }
        [HttpPost("Order")]
        public IActionResult Order(OrderViewModel model)
        {
            List<Pizza> pizzas = new List<Pizza>();
            foreach (PizzaViewModel pizzaViewModel in model.Pizzas)
            {
                pizzas.Add(_pizzaOrderService.GetPizzaFromMenu(pizzaViewModel.Name, pizzaViewModel.Size));
            }
            User user = new User()
            {
                Address = model.Address,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone
            };
            Order order = new Order()
            {
                Pizzas = pizzas,
                User = user
            };
            _pizzaOrderService.MakeNewOrder(order);
            return View("_ThankYou");
        }
    }
}