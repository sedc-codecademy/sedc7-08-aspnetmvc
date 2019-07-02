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
    public class TodoEntityFrameworkRepository : IGenericRepository<Todo>
    {
        private readonly TodoContext _dbContext;

        public TodoEntityFrameworkRepository(TodoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<Todo> GetAll(Expression<Func<Todo, bool>> filter = null, Func<IQueryable<Todo>, IIncludableQueryable<Todo, object>> include = null)
        {
            IQueryable<Todo> result = _dbContext.Set<Todo>();

            if (filter != null)
                result = result.Where(filter);

            if (include != null)
                result = include(result);

            return result.ToList();
        }

        public Todo FindById(int id, Func<IQueryable<Todo>, IIncludableQueryable<Todo, object>> include = null)
        {
            IQueryable<Todo> dbSet = _dbContext.Set<Todo>();

            if (include != null)
                dbSet = include(dbSet);

            return dbSet.SingleOrDefault(x => x.Id == id);
        }

        public void Create(Todo model)
        {
            _dbContext.Set<Todo>().Add(model);
            _dbContext.SaveChanges();
        }

        public void Update(Todo model)
        {
            _dbContext.Set<Todo>().Update(model);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var existingEntity = _dbContext.Set<Todo>().Find(id);
            _dbContext.Remove(existingEntity);
            _dbContext.SaveChanges();
        }
    }
}
