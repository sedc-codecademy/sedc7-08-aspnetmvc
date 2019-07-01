using SEDC.PizzaClass6.DomainModels;
using System.Collections.Generic;

namespace SEDC.PizzaClass6.DataLayer.Interfaces
{
    public interface IRepository<T>
        where T : Entity
    {
        T Get(int id);
        ICollection<T> GetAll();
        int Insert(T item);
        int Update(T item);
        void Delete(T item);
    }
}
