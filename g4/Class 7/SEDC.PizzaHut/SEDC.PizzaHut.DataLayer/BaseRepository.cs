using Microsoft.EntityFrameworkCore;
using SEDC.PizzaHut.DataLayer.Interfaces;
using SEDC.PizzaHut.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaHut.DataLayer
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : Entity
    {
        private readonly PizzaHutContext _db;
        private readonly DbSet<T> _entity;

        public BaseRepository(PizzaHutContext context)
        {
            _db = context;
            _entity = _db.Set<T>();
        }

        public int Delete(int id)
        {
            var dbItem = _entity.FirstOrDefault(i => i.Id.Equals(id));
            _entity.Remove(dbItem);
            return _db.SaveChanges();
        }

        public T Get(int id)
        {
            return _entity.FirstOrDefault(i => i.Id.Equals(id));
        }

        public ICollection<T> GetAll()
        {
            return _entity.ToList();
        }

        public int Insert(T item)
        {
            _entity.Add(item);
            return _db.SaveChanges();
        }

        public int Update(T item)
        {
            var pizza = _entity.Attach(item);
            pizza.State = EntityState.Modified;
            return _db.SaveChanges();
        }
    }
}
