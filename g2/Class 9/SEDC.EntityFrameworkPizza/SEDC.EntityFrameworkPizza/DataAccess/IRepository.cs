using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.EntityFrameworkPizza.DataAccess
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
