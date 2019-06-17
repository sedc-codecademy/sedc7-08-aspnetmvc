using System.ComponentModel.DataAnnotations;

namespace Sedc.FormValidation.WebApp.Models
{
    public class Pizza
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        public string Style { get; set; }

        [Required]
        [MinLength(10)]
        public string Ingredients { get; set; }

        [Required]
        [MinLength(10)]
        public string Allergens { get; set; }

        [Required]
        public bool IsVegan { get; set; }

        [Required]
        public bool IsFasting { get; set; }

        [Required]
        public bool IsHalal { get; set; }

        [Required]
        public bool IsKosher { get; set; }

        [Required]
        [Range(100, 1000)]
        public double Price { get; set; }
    }
}
