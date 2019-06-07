using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.G2.PizzApp.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public string OrderName { get; set; }
        [Required]
        public string Pizza { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Please select number from the range 1-10!")]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string User { get; set; }
    }
}
