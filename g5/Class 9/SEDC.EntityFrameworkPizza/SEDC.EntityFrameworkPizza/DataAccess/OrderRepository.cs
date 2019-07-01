using SEDC.EntityFrameworkPizza.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.EntityFrameworkPizza.DataAccess
{
    public class OrderRepository : IRepository<Order>
    {
        private PizzaDbContext _dbContext;
        public OrderRepository(PizzaDbContext context)
        {
            _dbContext = context;
        }
        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.SingleOrDefault(x => x.Id == id);
        }

        public void Insert(Order entity)
        {
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
