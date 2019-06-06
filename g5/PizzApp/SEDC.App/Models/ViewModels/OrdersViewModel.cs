using SEDC.App.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.App.Models.ViewModels
{
    public class OrdersViewModel
    {
        public string FirstPizza { get; set; }
        public int NumberOfOrders { get; set; }
        public string FirstPersonName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
