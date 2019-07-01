using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workshop.PizzaApp.Data.Interfaces;
using Workshop.PizzaApp.Data.Model;

namespace Workshop.PizzaApp.Data.Repositories
{
    public class PizzaSizeRepository : IPizzaSizeRepository
    {
        private PizzaAppDbContext _dbContext;

        public PizzaSizeRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddPizzaSize(PizzaSizeModel pizzaSize)
        {
            _dbContext.PizzaSizes.Add(pizzaSize);
            _dbContext.SaveChanges();
        }

        public void DeletePizzaSize(int pizzaSizeId)
        {
            var pizzaSize = GetPizzaSizeById(pizzaSizeId);
            if (pizzaSize != null)
            {
                _dbContext.Remove(pizzaSize);
                _dbContext.SaveChanges();
            }
        }

        public void EditPizzaSizePrice(PizzaSizeModel pizzaSize)
        {
            var pizzaSizeInDb = GetPizzaSizeById(pizzaSize.PizzaSizeId);
            if (pizzaSizeInDb != null)
            {
                pizzaSizeInDb.Price = pizzaSize.Price;
                _dbContext.Update(pizzaSizeInDb);
                _dbContext.SaveChanges();
            }
        }

        public List<PizzaSizeModel> GetAllPizzaSizes()
        {
            return _dbContext.PizzaSizes.Include(x => x.Pizza).Include(y => y.Size).ToList();
        }

        public PizzaSizeModel GetPizzaSizeById(int pizzaSizeId)
        {
            return _dbContext.PizzaSizes.Include(x => x.Pizza).Include(y => y.Size).FirstOrDefault(x => x.PizzaSizeId == pizzaSizeId);
        }
    }
}
