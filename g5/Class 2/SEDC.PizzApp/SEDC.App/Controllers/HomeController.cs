using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SEDC.App.Controllers
{
    [Route("Start/[Action]")]
    public class HomeController : Controller
    {
        [Route("Begin")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("CallMe")]
        public ViewResult Contact()
        {
            return View();
        }
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