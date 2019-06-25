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
        private IUserService _userService;
        public OrderController(IPizzaOrderService pizzaOrderService, IUserService userService)
        {
            _pizzaOrderService = pizzaOrderService;
            _userService = userService;
        }
        [Route("Orders")]
        public IActionResult Index()
        {
            // Domain models
            List<Order> orders = _pizzaOrderService.GetAllOrders();
            // View Models
            // MAPPINT SECTION
            List<OrderItemViewModel> viewOrders = new List<OrderItemViewModel>();
            foreach (Order order in orders)
            {
                List<PizzaViewModel> pizzasView = new List<PizzaViewModel>();
                foreach (var pizzaOrder in order.PizzaOrders)
                {
                    pizzasView.Add(new PizzaViewModel()
                    {
                        Id = pizzaOrder.Pizza.Id,
                        Image = pizzaOrder.Pizza.Image,
                        Name = pizzaOrder.Pizza.Name,
                        Price = pizzaOrder.Pizza.Price,
                        Size = pizzaOrder.Pizza.Size
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
                LastPizza = _pizzaOrderService.GetLastOrder().PizzaOrders[0].Pizza.Name,
                MostPopularPizza = _pizzaOrderService.GetMostPopularPizza(),
                NameOfFirstCustomer = _userService.GetLastUserName(),
                OrderCount = _pizzaOrderService.GetOrderCount(),
                Orders = viewOrders
            };
            // We send mapped view model to the view
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
            Order order = new Order();
            List<PizzaOrder> pizzas = new List<PizzaOrder>();
            foreach (PizzaViewModel pizzaViewModel in model.Pizzas)
            {
                PizzaOrder pizzaOrder = new PizzaOrder()
                {
                    Pizza = _pizzaOrderService.GetPizzaFromMenu(pizzaViewModel.Name, pizzaViewModel.Size),
                    Order = order
                };
                pizzaOrder.PizzaId = pizzaOrder.Pizza.Id;
                pizzas.Add(pizzaOrder);
            }
            User user = new User()
            {
                Address = model.Address,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone
            };
            order.PizzaOrders = pizzas;
            order.User = user;
            _pizzaOrderService.MakeNewOrder(order);
            return View("_ThankYou");
        }
        public IActionResult Details(int id)
        {
            Order order = _pizzaOrderService.GetOrderById(id);
            if (order == null) return View("_Error");
            List<PizzaViewModel> pizzas = new List<PizzaViewModel>();
            foreach (PizzaOrder pizzaOrder in order.PizzaOrders)
            {
                pizzas.Add(new PizzaViewModel()
                {
                    Image = pizzaOrder.Pizza.Image,
                    Name = pizzaOrder.Pizza.Name,
                    Price = pizzaOrder.Pizza.Price,
                    Size = pizzaOrder.Pizza.Size
                });
            }
            if (order == null) return View("_Error");
            OrderDetailsViewModel viewModel = new OrderDetailsViewModel()
            {
                Address = order.User.Address,
                Order = new OrderItemViewModel()
                {
                    Id = order.Id,
                    FirstName = order.User.FirstName,
                    Pizzas = pizzas,
                    LastName = order.User.LastName,
                    Price = order.Price
                },
                Phone = order.User.Phone
            };
            return View(viewModel);
        }
    }
}