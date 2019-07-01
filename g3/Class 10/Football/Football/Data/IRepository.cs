using Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Data
{
    public interface IRepository<T>
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);
        List<T> GetAll();
    }
}
