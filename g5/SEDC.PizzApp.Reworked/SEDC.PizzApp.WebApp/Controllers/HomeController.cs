using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzApp.Domain;
using SEDC.PizzApp.Services.Services;
using SEDC.PizzApp.WebApp.Models;

namespace SEDC.PizzApp.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IPizzaOrderService _pizzaOrderService;
        private IUserService _userService;
        public HomeController(IPizzaOrderService pizzaOrderService, IUserService userService)
        {
            _pizzaOrderService = pizzaOrderService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View(new HomeViewModel());
        }
        [HttpPost]
        public IActionResult Index(HomeViewModel model)
        {
            return RedirectToAction("Order", "Order", new { pizzas = model.NumberOfPizzas });
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Feedback()
        {
            return View(new FeedbackViewModel());
        }
        [HttpPost]
        public IActionResult Feedback(FeedbackViewModel model)
        {
            Feedback feedback = new Feedback()
            {
                Email = model.Email,
                Message = model.Message,
                Name = model.Name
            };
            _userService.GiveFeedback(feedback);
            return RedirectToAction("Index");
        }
        public IActionResult Menu()
        {
            List<Pizza> menu = _pizzaOrderService.GetMenu();
            List<PizzaViewModel> pizzasView = new List<PizzaViewModel>();
            foreach (var pizza in menu)
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
            MenuViewModel model = new MenuViewModel()
            {
                Menu = pizzasView
            };
            return View(model);
        }
    }
}
