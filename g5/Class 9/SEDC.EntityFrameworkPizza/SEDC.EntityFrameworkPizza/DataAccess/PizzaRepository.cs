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
        public PizzaRepository(PizzaDbContext context)
        {
            _dbContext = context;
        }

        public void Delete(Pizza entity)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAll()
        {
            return _dbContext.Pizzas.ToList(); ;
        }

        public Pizza GetById(int id)
        {
            return _dbContext.Pizzas.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(Pizza entity)
        {
            _dbContext.Pizzas.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Pizza entity)
        {
            throw new NotImplementedException();
        }
    }
}
