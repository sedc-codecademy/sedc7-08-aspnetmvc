using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzApp.Models
{
    public class PizzaPrice
    {
        [Key]
        public int PizzaId { get; set; }
        [Key]
        public int Size { get; set; }
        public double Price { get; set; }

        [ForeignKey("PizzaId")]
        public Pizza Pizza { get; set; }
    }
}
