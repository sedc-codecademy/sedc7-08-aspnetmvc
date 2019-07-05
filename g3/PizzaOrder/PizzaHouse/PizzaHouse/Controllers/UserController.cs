using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace PizzaHouse.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Login()
        {
            if (HttpContext.User.FindFirst(ClaimTypes.Name) != null)
            {
                return RedirectToAction("Menu", "Pizza");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = _userService.GetUser(model.Email, model.Password);

            if (user == null)
                RedirectToAction("Login");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
            };

            if (user.Name == "Risto")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            }

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Menu", "Pizza");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public string GetName()
        {
            var name = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            return string.IsNullOrEmpty(name) ? string.Empty : $"Hi {name}!";
        }
    }
}