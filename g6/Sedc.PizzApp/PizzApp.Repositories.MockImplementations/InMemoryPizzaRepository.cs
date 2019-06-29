using PizzApp.Models;
using PizzApp.Repositories.Abstractions;
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

        public void AddPrice(PizzaPrice pizzaPrice)
        {
            throw new System.NotImplementedException();
        }

        public Pizza Create(Pizza model)
        {
            var newPizza = new Pizza
            {
                Id = pizzas.Max(pizza => pizza.Id) + 1,
                Name = model.Name
            };
            pizzas.Add(newPizza);
            return newPizza;
        }

        public void Delete(int id)
        {
            var pizza = pizzas.First(x => x.Id == id);
            pizzas.Remove(pizza);
        }

        public List<Pizza> GetAllPizzas()
        {
            return pizzas;
        }
        public Pizza GetById(int id)
        {
            return pizzas.FirstOrDefault(p => p.Id == id);
        }

        public Pizza Update(Pizza model)
        {
            var pizza = pizzas.First(x => x.Id == model.Id);
            pizza.Name = model.Name;
            return pizza;
        }
    }
}
