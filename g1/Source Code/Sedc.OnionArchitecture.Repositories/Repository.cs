using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sedc.OnionArchitecture.Entities;
using Sedc.OnionArchitecture.Repositories.Interfaces;

namespace Sedc.OnionArchitecture.Repositories
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<TModel> GetAll(Expression<Func<TModel, bool>> filter = null)
        {
            var dbSet = _dbContext.Set<TModel>();

            if (filter == null)
                return dbSet.ToList();
            else
                return dbSet.Where(filter).ToList();
        }

        public TModel FindById(int id)
        {
            var dbSet = _dbContext.Set<TModel>();
            return dbSet.Find(id);
        }

        public void Create(TModel model)
        {
            var dbSet = _dbContext.Set<TModel>();
            dbSet.Add(model);
            _dbContext.SaveChanges();
        }

        public void Update(TModel model)
        {
            var dbSet = _dbContext.Set<TModel>();
            dbSet.Update(model);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var dbSet = _dbContext.Set<TModel>();
            var model = dbSet.Find(id);
            dbSet.Remove(model);
            _dbContext.SaveChanges();
        }
    }
}
