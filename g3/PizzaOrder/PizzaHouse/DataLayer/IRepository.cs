using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public interface IRepository<T>
    {
        List<T> GetAll(Func<IQueryable<T>, IQueryable<T>> func = null);
        T GetById(int id, Func<IQueryable<T>, IQueryable<T>> func = null);
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
