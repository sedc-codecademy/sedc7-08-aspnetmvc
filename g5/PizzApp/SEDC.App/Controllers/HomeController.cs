using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.App.Models.DomainModels;
using SEDC.App.Models.Enums;

namespace SEDC.App.Controllers
{
    //[Route("Start/[Action]")]
    public class HomeController : Controller
    {
        private Pizza _pizzaPromotion;
        public HomeController()
        {
            _pizzaPromotion = new Pizza()
            {
                Id = 1,
                Name = "Margarita",
                Price = 7,
                Size = PizzaSize.Medium
            };
        }
        //[Route("Begin")]
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet("CallMe")]
        public ViewResult Contact()
        {
            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }
        public IActionResult Promotion()
        {
            return View(_pizzaPromotion);
        }
        // Examples
        public IActionResult Nothing()
        {
            return new EmptyResult();
        }
        public IActionResult BackToHome()
        {
            return RedirectToAction("Index");
        }
        public IActionResult JsonData()
        {
            object order = new { OrderId = 12, OrderName = "Zdrave" };
            return new JsonResult(order);
        }
    }
}