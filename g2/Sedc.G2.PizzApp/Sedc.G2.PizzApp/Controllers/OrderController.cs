using Microsoft.AspNetCore.Mvc;
using Sedc.G2.PizzApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sedc.G2.PizzApp.Controllers
{
    public class OrderController : Controller
    {
        //this static list simulate orders stored in database
        public static List<OrderModel> orders = new List<OrderModel>
        {
            new OrderModel
            {
                Id = 1,
                OrderName = "Order 1",
                Pizza = "Capricioza",
                Quantity = 2,
                Price = 500
            },
            new OrderModel
            {
                Id = 2,
                OrderName = "Order 2",
                Pizza = "Peperoni",
                Quantity = 3,
                Price = 650,
                User = "John Doe"
            },
            new OrderModel
            {
                Id = 3,
                OrderName = "Order 3",
                Pizza = "Peperoni",
                Quantity = 5,
                Price = 1000,
                User = "Jane Doe"
            }
        };
        public IActionResult Index()
        {
            //send all orders to orders default page
            return View(orders);
        }

        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Method that selects order from the list of orders by the suplied Id and send 
        /// it to OrderDetails view for siaplaying hte order detail
        /// </summary>
        /// <param name="id">Id of the order that details should be displayed</param>
        /// <returns>order that should be displayed</returns>
        public IActionResult OrderDetails(int id)
        {
            var order = orders.FirstOrDefault(x => x.Id == id);
            return View(order);
        }
    }
}