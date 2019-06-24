using SEDC.PizzaHut.Domain;
using System.Collections.Generic;

namespace SEDC.PizzaHut.DataLayer.Interfaces
{
    public interface IRepository<T>
        where T : Entity
    {
        T Get(int id);
        ICollection<T> GetAll();
        int Insert(T item);
        int Update(T item);
        int Delete(int id);
    }
}
