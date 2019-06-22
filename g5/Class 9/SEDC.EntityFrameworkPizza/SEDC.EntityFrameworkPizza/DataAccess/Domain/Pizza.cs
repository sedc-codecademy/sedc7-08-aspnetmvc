using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.EntityFrameworkPizza.DataAccess.Domain
{
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public PizzaSize Size { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
    public enum PizzaSize
    {
        Medium,
        Large,
        Family
    }
}
