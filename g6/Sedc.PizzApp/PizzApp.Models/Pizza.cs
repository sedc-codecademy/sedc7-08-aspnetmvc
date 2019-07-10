using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzApp.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        //[Column("Pizza Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<PizzaPrice> PizzaPrices { get; set; }
    }
}
