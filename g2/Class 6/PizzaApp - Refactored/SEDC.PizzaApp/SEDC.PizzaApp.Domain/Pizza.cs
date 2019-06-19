using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Domain
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PizzaSize Size { get; set; }
        public int Price { get; set; }
    }
}
