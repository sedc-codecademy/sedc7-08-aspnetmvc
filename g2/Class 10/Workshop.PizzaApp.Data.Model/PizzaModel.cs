using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text;

namespace Workshop.PizzaApp.Data.Model
{
    [Table("Pizza", Schema = "dbo")]
    public class PizzaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Pizza Id")]
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
