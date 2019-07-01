using SEDC.PizzaHut.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaHut.BusinessLayer.ViewModels
{
    public class PizzaTypeViewModel
    {
        public PizzaTypeViewModel(PizzaType pizzaType)
        {
            Id = pizzaType.Id;
            Name = pizzaType.Name;
            Description = pizzaType.Description;
            Photo = pizzaType.Photo;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }
    }
}
