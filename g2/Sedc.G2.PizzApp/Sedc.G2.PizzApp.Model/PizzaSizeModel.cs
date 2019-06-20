using System;
using System.Collections.Generic;
using System.Text;

namespace Sedc.G2.PizzApp.Model
{
    public class PizzaSizeModel
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }
    }
}
