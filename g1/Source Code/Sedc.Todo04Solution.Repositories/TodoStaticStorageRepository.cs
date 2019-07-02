
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Sedc.Todo03Solution.Entities;
using Sedc.Todo03Solution.Repositories.Interfaces;

namespace Sedc.Todo03Solution.Repositories
{
    public class TodoStaticStorageRepository : IGenericRepository<Todo>
    {
        public TodoStaticStorageRepository()
        {
        }

        public ICollection<Todo> GetAll(Expression<Func<Todo, bool>> filter = null, Func<IQueryable<Todo>, IIncludableQueryable<Todo, object>> include = null)
        {
            return StaticStorage<Todo>.DataSet.ToList();
        }

        public Todo FindById(int id, Func<IQueryable<Todo>, IIncludableQueryable<Todo, object>> include = null)
        {
            return StaticStorage<Todo>.DataSet.SingleOrDefault(x => x.Id == id);
        }

        public void Create(Todo model)
        {
            StaticStorage<Todo>.DataSet.Add(model);
        }

        public void Update(Todo model)
        {
            var existingEntityIndex = StaticStorage<Todo>.DataSet.IndexOf(StaticStorage<Todo>.DataSet.SingleOrDefault(x => x.Id == model.Id));
            StaticStorage<Todo>.DataSet[existingEntityIndex] = model;
        }

        public void DeleteById(int id)
        {
            var existingEntityIndex = StaticStorage<Todo>.DataSet.IndexOf(StaticStorage<Todo>.DataSet.SingleOrDefault(x => x.Id == id));
            StaticStorage<Todo>.DataSet.RemoveAt(existingEntityIndex);
        }
    }
}
