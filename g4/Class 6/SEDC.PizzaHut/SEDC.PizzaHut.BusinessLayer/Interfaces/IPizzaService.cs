using SEDC.PizzaHut.BusinessLayer.ViewModels;
using SEDC.PizzaHut.Domain.Models;
using System.Collections.Generic;

namespace SEDC.PizzaHut.BusinessLayer.Interfaces
{
    public interface IPizzaService
    {
        int AddPizza(CreatePizzaViewModel pizza);
        int EditPizza(EditPizzaViewModel pizza);
        int RemovePizza(int id);
        PizzaViewModel GetById(int id);
        List<PizzaViewModel> GetAll();
    }
}
