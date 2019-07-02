using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Workshop.PizzaApp.Model
{
    public class PizzaSizeViewModel
    {
        [Display(Name = "Pizza Size Id")]
        public int? PizzaSizeId { get; set; }
        [Required]
        public int PizzaId { get; set; }
        [Display(Name = "Pizza")]
        public string PizzaName { get; set; }
        [Required]
        public int SizeId { get; set; }
        [Display(Name = "Size")]
        public string SizeName { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
