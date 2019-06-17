using PizzaHut.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.MockRepositories
{
    public class MockPizzaRepository : IPizzaRepository
    {
        List<Pizza> pizzas;
        public MockPizzaRepository()
        {
            pizzas = new List<Pizza>()
            {
                new Pizza{ID=1, Name="Caprichiosa",PizzaTypeID=1, Size=SizeEnum.Small,Price=150},
                new Pizza{ID=2, Name="Quatro stagone",PizzaTypeID=2, Size=SizeEnum.Medium,Price=200},
                new Pizza{ID=3, Name="Vegetariana",PizzaTypeID=3, Size=SizeEnum.Large,Price=250},
            };
        }
        public Pizza Add(Pizza pizza) //Create
        {
            int nextId = pizzas.Max(p => p.ID) + 1;
            pizza.ID = nextId;
            pizzas.Add(pizza);
            return pizza;
        }

        public Pizza Delete(int id)
        {
            Pizza pizza = pizzas.FirstOrDefault(p => p.ID == id);
            pizzas.Remove(pizza);
            return pizza;
        }

        public Pizza Get(int id)
        {
            Pizza pizza = pizzas.FirstOrDefault(p => p.ID == id);
            return pizza;
        }

        public IEnumerable<Pizza> GetAll()
        {
            return pizzas;
        }

        public Pizza Update(Pizza pizzaChanges)
        {
            Pizza pizza = pizzas.FirstOrDefault(p => p.ID == pizzaChanges.ID);
            if (pizza != null)
            {
                pizza.Name = pizzaChanges.Name;
                pizza.PizzaType = pizzaChanges.PizzaType;
                pizza.Price = pizzaChanges.Price;
                pizza.Size = pizzaChanges.Size;                
            }
            return pizza;
        }
    }
}
