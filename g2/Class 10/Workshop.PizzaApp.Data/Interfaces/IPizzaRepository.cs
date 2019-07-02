using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Data.Model;

namespace Workshop.PizzaApp.Data.Interfaces
{
    public interface IPizzaRepository
    {

        List<PizzaModel> GetAllPizzas();

        PizzaModel GetPizzaById(int pizzaId);

        void AddPizza(PizzaModel pizza);

        void DeletePizza(int pizzaId);

        void EditPizza(PizzaModel pizza);
    }
}
