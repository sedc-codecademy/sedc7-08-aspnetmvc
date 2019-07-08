using System.Security.Claims;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace PizzaHouse.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        [Authorize]
        public IActionResult Create()
        {
            if (HttpContext.User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Menu", "Pizza");
            }

            var user = _userService.GetUserByEmail(HttpContext.User.FindFirst(ClaimTypes.Name).Value);

            var order = _orderService.GetEmptyOrder();
            order.Email = user.Email;
            order.Address = user.Address;
            order.Phone = user.Phone;

            return View(order);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            if (HttpContext.User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Menu", "Pizza");
            }

            _orderService.CreateOrder(model);
            return RedirectToAction("Menu", "Pizza");
        }

        [Authorize]
        public IActionResult List()
        {
            if (!HttpContext.User.HasClaim(ClaimTypes.Role, "Administrator"))
            {
                RedirectToAction("Menu", "Pizza");
            }

            var orders = _orderService.GetAllOrders();
            return View(orders);
        }
    }
}