using Microsoft.AspNetCore.Mvc;

namespace Sedc.PizzApp.WebDemo.Controllers
{
    public class SedcController : Controller
    {


        public IActionResult IsItSedcDay()
        {
            return View();
        }

        //public IActionResult IsItSedcDay()
        //{
        //    return View("~/Views/Sedc/IsItSedcDay.cshtml");
        //}
    }
}
