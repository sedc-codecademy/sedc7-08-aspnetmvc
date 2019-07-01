using SEDC.PizzaHut.Domain.Enums;
using SEDC.PizzaHut.Domain.Models;
using System.ComponentModel;

namespace SEDC.PizzaHut.BusinessLayer.ViewModels
{
    public class PizzaViewModel
    {
        public PizzaViewModel(Pizza pizza)
        {
            Id = pizza.Id;
            Name = pizza.Name;
            Size = pizza.Size;
            Price = pizza.Price;
            PizzaType = new PizzaTypeViewModel(pizza.PizzaType);
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public SizeEnum Size { get; set; }

        public decimal Price { get; set; }
        
        [DisplayName("Pizza Type")]
        public PizzaTypeViewModel PizzaType { get; set; }
    }
}
