using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace PizzaHouse.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Create()
        {
            return View(_orderService.GetEmptyOrder());
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {
            _orderService.CreateOrder(model);
            return RedirectToAction("Menu", "Pizza");
        }

        public IActionResult List()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }
    }
}