using SEDC.PizzApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzApp.WebApp.Models
{
    public class OrdersViewModel
    {
        public List<OrderItemViewModel> Orders { get; set; }
        public int OrderCount { get; set; }
        public string LastPizza { get; set; }
        public string MostPopularPizza { get; set; }
        public string NameOfFirstCustomer { get; set; }
    }
}
