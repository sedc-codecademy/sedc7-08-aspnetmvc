using Microsoft.AspNetCore.Mvc;

namespace Sedc.PizzApp.WebDemo.Controllers
{

    public class OrderController : Controller
    {
        [Route("/user/{userId:range(1,2000000000)}/pizza/{pizzaId:int}/order/{orderId}")]
        //[ActionName("history")]
        public IActionResult GetUserPizzaOrder
            (int userId, int pizzaId, string orderId)
        {
            var pizzas = new string[] {
                "margharita",
                "pepperoni",
                "capri"
            };
            return new OkObjectResult(pizzas);
        }
    }
}
