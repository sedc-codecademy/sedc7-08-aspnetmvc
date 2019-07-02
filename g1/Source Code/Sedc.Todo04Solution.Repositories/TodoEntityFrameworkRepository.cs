using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Sedc.Todo03Solution.Entities;
using Sedc.Todo03Solution.Repositories.Interfaces;

namespace Sedc.Todo03Solution.Repositories
{
    public class TodoEntityFrameworkRepository : IGenericRepository
    {
        private readonly TodoContext _dbContext;

        public TodoEntityFrameworkRepository(TodoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<TModel> GetAll<TModel>(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null) where TModel : BaseEntity
        {
            IQueryable<TModel> result = _dbContext.Set<TModel>();

            if (filter != null)
                result = result.Where(filter);

            if (include != null)
                result = include(result);

            return result.ToList();
        }

        public TModel FindById<TModel>(int id, Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null) where TModel : BaseEntity
        {
            IQueryable<TModel> dbSet = _dbContext.Set<TModel>();

            if (include != null)
                dbSet = include(dbSet);

            return dbSet.SingleOrDefault(x => x.Id == id);
        }

        public void Create<TModel>(TModel model) where TModel : BaseEntity
        {
            _dbContext.Set<TModel>().Add(model);
            _dbContext.SaveChanges();
        }

        public void Update<TModel>(TModel model) where TModel : BaseEntity
        {
            _dbContext.Set<TModel>().Update(model);
            _dbContext.SaveChanges();
        }

        public void DeleteById<TModel>(int id) where TModel : BaseEntity
        {
            var existingEntity = _dbContext.Set<TModel>().Find(id);
            _dbContext.Remove(existingEntity);
            _dbContext.SaveChanges();
        }
    }
}
