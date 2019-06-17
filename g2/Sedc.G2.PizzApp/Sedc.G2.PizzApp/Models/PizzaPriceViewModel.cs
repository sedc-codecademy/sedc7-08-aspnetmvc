using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.G2.PizzApp.Models
{
    public class PizzaPriceViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int PizzaId { get; set; }
        [Required]
        public int SizeId { get; set; }
        [Required]
        public decimal Price { get; set; }

        public SelectList Pizzas { get; set; }
        public SelectList Sizes { get; set; }
    }
}
