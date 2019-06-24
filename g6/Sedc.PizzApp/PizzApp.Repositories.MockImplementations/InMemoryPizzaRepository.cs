using PizzApp.Models;
using PizzApp.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzApp.Repositories.MockImplementations
{
    public class InMemoryPizzaRepository : IPizzaRepository
    {
        private static readonly List<Pizza> pizzas = new List<Pizza>
            {
               new Pizza{ Id=1, Name="capri" },
               new Pizza{ Id=2, Name="tuna" },
               new Pizza{ Id=3, Name="margarita" },
               new Pizza{ Id=4, Name="pepperoni" },
            };

        public List<Pizza> GetAllPizzas()
        {
            return pizzas;
        }
        public Pizza GetById(int id)
        {
            return pizzas.FirstOrDefault(p => p.Id == id);
        }
    }
}
