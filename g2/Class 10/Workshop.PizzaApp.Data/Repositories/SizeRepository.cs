using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workshop.PizzaApp.Data.Interfaces;
using Workshop.PizzaApp.Data.Model;

namespace Workshop.PizzaApp.Data.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private PizzaAppDbContext _dbContext;

        public SizeRepository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSize(SizeModel size)
        {
            _dbContext.Sizes.Add(size);
            _dbContext.SaveChanges();
        }

        public void DeleteSize(int sizeId)
        {
            var size = GetSizeById(sizeId);
            if (size != null)
            {
                _dbContext.Remove(size);
                _dbContext.SaveChanges();
            }
        }

        public void EditSize(SizeModel size)
        {
            var sizeInDb = GetSizeById(size.SizeId);
            if (sizeInDb != null)
            {
                sizeInDb.Name = size.Name;
                sizeInDb.Diameter = size.Diameter;
                _dbContext.Update(sizeInDb);
                _dbContext.SaveChanges();
            }
        }

        public List<SizeModel> GetAllSizes()
        {
            return _dbContext.Sizes.ToList();
        }

        public SizeModel GetSizeById(int sizeId)
        {
            return _dbContext.Sizes.FirstOrDefault(x => x.SizeId == sizeId);
        }
    }
}
