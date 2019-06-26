using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Sedc.OnionArchitecture.Repositories.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {
        ICollection<TModel> GetAll(Expression<Func<TModel, bool>> filter = null);
        TModel FindById(int id);
        void Create(TModel model);
        void Update(TModel model);
        void DeleteById(int id);
    }
}