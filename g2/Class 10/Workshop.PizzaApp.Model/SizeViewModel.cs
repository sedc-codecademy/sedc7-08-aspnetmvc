using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Workshop.PizzaApp.Model
{
    public class SizeViewModel
    {
        [Display(Name = "Size Id")]
        public int? SizeId { get; set; }

        [Required]
        [Display(Name = "Size Name")]
        public string Name { get; set; }

        [Required]
        public int Diameter { get; set; }
    }
}
