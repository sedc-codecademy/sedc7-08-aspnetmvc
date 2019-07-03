using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Workshop.PizzaApp.Data.Model
{
    [Table("PizzaOrder", Schema = "dbo")]
    public class PizzaOrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Pizza Order Id")]
        public int PizzaOrderId { get; set; }
        [ForeignKey("Order")]
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("PizzaSize")]
        [Required]
        public int PizzaSizeId { get; set; }
        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        public virtual OrderModel Order { get; set; }
        public virtual PizzaSizeModel PizzaSize { get; set; }
    }
}
