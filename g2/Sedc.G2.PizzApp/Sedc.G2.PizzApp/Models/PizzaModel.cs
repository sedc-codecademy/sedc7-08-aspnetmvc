using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.G2.PizzApp.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(100, 1100, ErrorMessage = "Price must be in range 100-1100!")]
        public decimal Price { get; set; }
        [Required]
        public string Size { get; set; }
    }
}
