using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Sedc.Todo03Solution.Entities;

namespace Sedc.Todo03Solution.Repositories.Interfaces
{
    public interface IGenericRepository
    {
        ICollection<TModel> GetAll<TModel>(Expression<Func<TModel, bool>> filter = null, Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null) where TModel : BaseEntity;
        TModel FindById<TModel>(int id, Func<IQueryable<TModel>, IIncludableQueryable<TModel, object>> include = null) where TModel : BaseEntity;
        void Create<TModel>(TModel model) where TModel : BaseEntity;
        void Update<TModel>(TModel model) where TModel : BaseEntity;
        void DeleteById<TModel>(int id) where TModel : BaseEntity;
    }
}