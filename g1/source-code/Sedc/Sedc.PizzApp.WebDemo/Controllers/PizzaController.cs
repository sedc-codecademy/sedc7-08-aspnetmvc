using Microsoft.AspNetCore.Mvc;

namespace Sedc.PizzApp.WebDemo.Controllers
{
    public class PizzaController: Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }

        //public IActionResult GetAll()
        //{
        //    return View("~/Views/Pizza/GetAll.cshtml");
        //}
    }
}
