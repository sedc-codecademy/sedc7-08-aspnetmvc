using SEDC.PizzaApp.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaApp.DataAccess
{
    public class PizzaRepository : IRepository<Pizza>
    {
        public List<Pizza> GetAll()
        {
            return StorageDB.Pizzas;
        }

        public Pizza GetById(int id)
        {
            return StorageDB.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Pizza pizza)
        {
            int newId = StorageDB.PizzaId++;
            pizza.Id = newId;
            StorageDB.Pizzas.Add(pizza);
        }

        public void Update(Pizza entity)
        {
            Pizza pizza = StorageDB.Pizzas.SingleOrDefault(x => x.Id == entity.Id);
            if(pizza != null)
            {
                int index = StorageDB.Pizzas.IndexOf(pizza);
                StorageDB.Pizzas[index] = pizza;
            }
        }

        public void Delete(int id)
        {
            Pizza pizza = StorageDB.Pizzas.SingleOrDefault(x => x.Id == id);
            if(pizza != null)
            {
                StorageDB.Pizzas.Remove(pizza);
            }
        }
        
    }
}
