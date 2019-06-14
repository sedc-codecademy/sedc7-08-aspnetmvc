using System.Collections.Generic;

namespace PizzaHouse.Data
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
