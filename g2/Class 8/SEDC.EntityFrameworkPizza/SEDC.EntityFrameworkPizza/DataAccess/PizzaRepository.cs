using SEDC.EntityFrameworkPizza.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.EntityFrameworkPizza.DataAccess
{
    public class PizzaRepository : IRepository<Pizza>
    {
        private PizzaDbContext _dbContext;

        public PizzaRepository(PizzaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Pizza> GetAll()
        {
            return _dbContext.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            return _dbContext.Pizzas.SingleOrDefault(x => x.Id == id);
        }


        public void Create(Pizza entity)
        {
            _dbContext.Pizzas.Add(entity);
            _dbContext.SaveChanges();
        }
        
        public void Update(Pizza entity)
        {
            Pizza pizza = _dbContext.Pizzas.SingleOrDefault(x => x.Id == entity.Id);
            if(pizza != null)
            {
                _dbContext.Pizzas.Update(entity);
                _dbContext.SaveChanges();
            }
        }


        public void Delete(Pizza entity)
        {
            Pizza pizza = _dbContext.Pizzas.SingleOrDefault(x => x.Id == entity.Id);
            if(pizza != null)
            {
                _dbContext.Pizzas.Remove(pizza);
                _dbContext.SaveChanges();
            }
        }


    }
}
