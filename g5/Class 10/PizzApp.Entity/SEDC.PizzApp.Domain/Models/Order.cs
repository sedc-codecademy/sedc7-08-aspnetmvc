using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SEDC.PizzApp.Domain
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public List<PizzaOrder> PizzaOrders { get; set; } = new List<PizzaOrder>();
        [NotMapped]
        public double Price
        {
            get
            {
                return PizzaOrders.Sum(x => x.Pizza.Price) + 2;
            }
        }
    }
}
