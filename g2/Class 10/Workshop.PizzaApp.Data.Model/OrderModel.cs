using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Workshop.PizzaApp.Data.Model
{
    [Table("Order", Schema = "dbo")]
    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual UserModel User { get; set; }
    }
}
