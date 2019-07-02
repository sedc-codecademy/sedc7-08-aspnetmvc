
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Sedc.Todo03Solution.Entities;
using Sedc.Todo03Solution.Repositories.Interfaces;

namespace Sedc.Todo03Solution.Repositories
{
    public class TodoStaticStorageRepository : IGenericRepository
    {
        public TodoStaticStorageRepository()
        {
        }

        public ICollection<TModel> GetAll<TModel>(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null) where TModel : BaseEntity
        {
            return StaticStorage<TModel>.DataSet.ToList();
        }

        public TModel FindById<TModel>(int id, Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null) where TModel : BaseEntity
        {
            return StaticStorage<TModel>.DataSet.SingleOrDefault(x => x.Id == id);
        }

        public void Create<TModel>(TModel model) where TModel : BaseEntity
        {
            StaticStorage<TModel>.DataSet.Add(model);
        }

        public void Update<TModel>(TModel model) where TModel : BaseEntity
        {
            var existingEntityIndex = StaticStorage<TModel>.DataSet.IndexOf(StaticStorage<TModel>.DataSet.SingleOrDefault(x => x.Id == model.Id));
            StaticStorage<TModel>.DataSet[existingEntityIndex] = model;
        }

        public void DeleteById<TModel>(int id) where TModel : BaseEntity
        {
            var existingEntityIndex = StaticStorage<TModel>.DataSet.IndexOf(StaticStorage<TModel>.DataSet.SingleOrDefault(x => x.Id == id));
            StaticStorage<TModel>.DataSet.RemoveAt(existingEntityIndex);
        }
    }
}
