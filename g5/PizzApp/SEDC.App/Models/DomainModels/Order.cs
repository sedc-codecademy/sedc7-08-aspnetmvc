using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.App.Models.DomainModels
{
    public class Order
    {
        public int Id { get; set; }
        public Pizza Pizza { get; set; }
        public double Price { get; set; }
        public User User { get; set; }
    }
}
