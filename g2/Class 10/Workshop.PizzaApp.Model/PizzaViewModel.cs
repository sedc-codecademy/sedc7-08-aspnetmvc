using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Workshop.PizzaApp.Model
{
    public class PizzaViewModel
    {

        [Display(Name = "Pizza Id")]
        public int? PizzaId { get; set; }

        [Required]
        [Display(Name = "Pizza Name")]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
