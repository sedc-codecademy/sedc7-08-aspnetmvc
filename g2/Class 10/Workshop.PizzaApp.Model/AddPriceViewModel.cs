using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop.PizzaApp.Model
{
    public class AddPriceViewModel
    {
        public PizzaSizeViewModel PizzaSize { get; set; }

        public SelectList Pizzas { get; set; }
        public SelectList Sizes { get; set; }
    }
}
