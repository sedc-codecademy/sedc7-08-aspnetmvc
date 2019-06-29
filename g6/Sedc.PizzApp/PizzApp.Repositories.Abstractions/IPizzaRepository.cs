using PizzApp.Models;
using System.Collections.Generic;

namespace PizzApp.Repositories.Abstractions
{
    public interface IPizzaRepository
    {
        List<Pizza> GetAllPizzas();
        Pizza GetById(int id);
        Pizza Create(Pizza model);
        Pizza Update(Pizza model);
        void Delete(int id);
        void AddPrice(PizzaPrice pizzaPrice);
    }
}
