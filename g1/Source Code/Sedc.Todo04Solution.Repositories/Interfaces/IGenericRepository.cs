using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Sedc.Todo03Solution.Entities;

namespace Sedc.Todo03Solution.Repositories.Interfaces
{
    public interface IGenericRepository<TModel> where TModel : BaseEntity
    {
        ICollection<TModel> GetAll(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null);
        TModel FindById(int id, Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null);
        void Create(TModel model);
        void Update(TModel model);
        void DeleteById(int id);
    }
}