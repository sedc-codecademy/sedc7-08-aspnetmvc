using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Workshop.PizzaApp.Data.Model
{
    [Table("Size", Schema = "dbo")]
    public class SizeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Size Id")]
        public int SizeId { get; set; }
        public string Name { get; set; }
        public int Diameter { get; set; }
    }
}
