using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaClass6.BusinessLayer.Interfaces;

namespace SEDC.PizzaClass6.WebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var response = _userService.GetAllUsers();
            return View(response);
        }
    }
}
