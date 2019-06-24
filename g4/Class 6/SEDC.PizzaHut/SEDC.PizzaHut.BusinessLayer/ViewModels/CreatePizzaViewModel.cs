using SEDC.PizzaHut.Domain.Enums;
using System.ComponentModel;

namespace SEDC.PizzaHut.BusinessLayer.ViewModels
{
    public class CreatePizzaViewModel
    {
        public string Name { get; set; }

        [DisplayName("Pizza Type")]
        public int PizzaTypeId { get; set; }

        public SizeEnum Size { get; set; }

        public decimal Price { get; set; }
    }
}
