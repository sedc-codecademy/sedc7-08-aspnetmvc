using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.ViewModels
{
    public class CreatePizzaViewModel
    {
        public string Name { get; set; }
        public int PizzaTypeID { get; set; }
        public SizeEnum Size { get; set; }
        public decimal Price { get; set; }
    }
}
