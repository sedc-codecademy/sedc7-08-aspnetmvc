using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workshop.PizzaApp.Data.Interfaces;
using Workshop.PizzaApp.Data.Model;

namespace Workshop.PizzaApp.Data.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private PizzaAppDbContext _dbContext;

        public PizzaRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPizza(PizzaModel pizza)
        {
            _dbContext.Pizzas.Add(pizza);
            _dbContext.SaveChanges();
        }

        public void DeletePizza(int pizzaId)
        {
            var pizza = GetPizzaById(pizzaId);
            if (pizza != null)
            {
                _dbContext.Remove(pizza);
                _dbContext.SaveChanges();
            }
        }

        public void EditPizza(PizzaModel pizza)
        {
            var pizzaInDb = GetPizzaById(pizza.PizzaId);
            if (pizzaInDb != null)
            {
                pizzaInDb.Name = pizza.Name;
                pizzaInDb.Description = pizza.Description;
                _dbContext.Update(pizzaInDb);
                _dbContext.SaveChanges();
            }
        }

        public List<PizzaModel> GetAllPizzas()
        {
            return _dbContext.Pizzas.ToList();
        }

        public PizzaModel GetPizzaById(int pizzaId)
        {
            return _dbContext.Pizzas.FirstOrDefault(x => x.PizzaId == pizzaId);
        }
    }
}
