using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sedc.OnionArchitecture.Repositories.Interfaces;

namespace Sedc.OnionArchitecture.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<TModel> GetAll<TModel>(Expression<Func<TModel, bool>> filter = null) where TModel : class
        {
            var dbSet = _dbContext.Set<TModel>();

            if (filter == null)
                return dbSet.ToList();
            else
                return dbSet.Where(filter).ToList();
        }

        public TModel FindById<TModel>(int id) where TModel : class
        {
            var dbSet = _dbContext.Set<TModel>();
            return dbSet.Find(id);
        }

        public void Create<TModel>(TModel model) where TModel : class
        {
            var dbSet = _dbContext.Set<TModel>();
            dbSet.Add(model);
            _dbContext.SaveChanges();
        }

        public void Update<TModel>(TModel model) where TModel : class
        {
            var dbSet = _dbContext.Set<TModel>();
            dbSet.Update(model);
            _dbContext.SaveChanges();
        }

        public void DeleteById<TModel>(int id) where TModel : class
        {
            var dbSet = _dbContext.Set<TModel>();
            var model = dbSet.Find(id);
            dbSet.Remove(model);
            _dbContext.SaveChanges();
        }
    }
}
