using SEDC.PizzaHut.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SEDC.PizzaHut.BusinessLayer.ViewModels
{
    public class CreatePizzaViewModel
    {
        [Required]
        public string Name { get; set; }

        [DisplayName("Pizza Type")]
        public int PizzaTypeId { get; set; }

        public SizeEnum Size { get; set; }

        public decimal Price { get; set; }
    }
}
