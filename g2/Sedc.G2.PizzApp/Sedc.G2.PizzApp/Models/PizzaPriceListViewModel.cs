using Sedc.G2.PizzApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.G2.PizzApp.Models
{
    public class PizzaPriceListViewModel
    {
        public List<Model.PizzaSizeModel> PizzaPrices { get; set; }

        public List<Model.PizzaModel> Pizzas { get; set; }

        public List<Model.SizeModel> Sizes { get; set; }
    }
}
