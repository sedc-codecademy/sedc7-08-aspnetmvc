using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sedc.OnionArchitecture.Repositories.Interfaces
{
    public interface IGenericRepository
    {
        ICollection<TModel> GetAll<TModel>(Expression<Func<TModel, bool>> filter = null) where TModel : class;
        TModel FindById<TModel>(int id) where TModel : class;
        void Create<TModel>(TModel model) where TModel : class;
        void Update<TModel>(TModel model) where TModel : class;
        void DeleteById<TModel>(int id) where TModel : class;
    }
}