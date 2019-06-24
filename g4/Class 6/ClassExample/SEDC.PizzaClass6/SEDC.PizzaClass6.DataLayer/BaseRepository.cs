using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SEDC.PizzaClass6.DataLayer.Interfaces;
using SEDC.PizzaClass6.DomainModels;

namespace SEDC.PizzaClass6.DataLayer
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : Entity
    {
        private readonly UserContext db;
        private readonly DbSet<T> entity;

        public BaseRepository(UserContext context)
        {
            db = context;
            entity = db.Set<T>();
        }

        public void Delete(T item)
        {
            var dbItem = entity.FirstOrDefault(i => i.Id.Equals(item.Id));
            entity.Remove(dbItem);
            db.SaveChanges();
        }

        public T Get(int id)
        {
            return entity.FirstOrDefault(t => t.Id.Equals(id));
        }

        public ICollection<T> GetAll()
        {
            return entity.ToList();
        }

        public int Insert(T item)
        {
            entity.Add(item);
            return db.SaveChanges();
        }

        public int Update(T item)
        {
            var pizza = entity.Attach(item);
            pizza.State = EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
