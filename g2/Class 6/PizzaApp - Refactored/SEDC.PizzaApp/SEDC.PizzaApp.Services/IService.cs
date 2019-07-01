using SEDC.PizzaApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services
{
    public interface IService
    {
        List<Pizza> GetAllPizzas();
        Pizza GetPizzaById(int id);
        void CreatePizza(Pizza pizza);
        void UpdatePizza(Pizza pizza);
        void DeletePizzaById(int id);
    }
}
