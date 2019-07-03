using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Workshop.PizzaApp.Data.Model
{
    [Table("PizzaSize", Schema = "dbo")]
    public class PizzaSizeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Pizza Size Id")]
        public int PizzaSizeId { get; set; }
        [ForeignKey("Pizza")]
        [Required]
        public int PizzaId { get; set; }
        [ForeignKey("Size")]
        [Required]
        public int SizeId { get; set; }
        [Required]
        public decimal Price { get; set; }

        public virtual PizzaModel Pizza { get; set; }
        public virtual SizeModel Size { get; set; }
    }
}
