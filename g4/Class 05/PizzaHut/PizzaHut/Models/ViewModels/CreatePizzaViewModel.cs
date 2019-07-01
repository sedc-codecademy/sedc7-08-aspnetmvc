using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.ViewModels
{
    public class CreatePizzaViewModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Pizza Type")]
        public int PizzaTypeID { get; set; }

        [Required]
        public SizeEnum Size { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
