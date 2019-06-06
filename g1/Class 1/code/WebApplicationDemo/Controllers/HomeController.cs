using System.Web.Mvc;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    public class HomeController : Controller
    {
        public string GetFullName()
        {
            return "vasheto ime e: " + "xhevo";
        }
    }
}