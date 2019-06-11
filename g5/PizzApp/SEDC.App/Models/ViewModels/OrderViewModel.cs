using SEDC.App.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.App.Models.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address for delivery")]
        public string Address { get; set; }
        public long Phone { get; set; }
        [Display(Name = "Type of pizza")]
        public string Pizza { get; set; }
        public PizzaSize Size { get; set; }
    }
}
