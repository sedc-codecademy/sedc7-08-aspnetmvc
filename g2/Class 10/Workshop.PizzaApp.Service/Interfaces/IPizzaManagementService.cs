using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Model;

namespace Workshop.PizzaApp.Service.Interfaces
{
    public interface IPizzaManagementService
    {
        List<PizzaViewModel> GetAllPizzas();

        PizzaViewModel GetPizzaById(int pizzaId);

        void AddPizza(PizzaViewModel pizza);

        void UpdatePizza(PizzaViewModel pizza);

        void DeletePizza(int pizzaId);
    }
}
