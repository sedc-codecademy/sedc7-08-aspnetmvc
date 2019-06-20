using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<Pizza> Pizzas { get; set; }

        public double TotalPrice
        {
            get
            {
                return Pizzas.Sum(x => x.Price) + 10;
            }

            //get => Pizzas.Sum(x => x.Price) + 10;
        }
    }
}
