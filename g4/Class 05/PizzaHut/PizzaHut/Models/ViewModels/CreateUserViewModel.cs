using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [Display(Name ="Full Name")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Compare("Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [MinLength(5)]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(?:[\s-][a-zA-Z]+)*$",
            ErrorMessage ="City is not a valid format")]
        public string City { get; set; }

        public string Phone { get; set; }
    }
}
