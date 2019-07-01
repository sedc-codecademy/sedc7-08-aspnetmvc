using System.Collections.Generic;

namespace SEDC.PizzaApp.DataAccess
{
    public interface IRepository<T> where T : class 
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
