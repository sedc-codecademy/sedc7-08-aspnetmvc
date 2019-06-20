using System;
using System.Collections.Generic;
using System.Linq;
using DtoModels;

namespace DataLayer
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        #region Working with static data
        /*public List<T> GetAll()
        {
            Type t = typeof(Storage);
            FieldInfo[] fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach (FieldInfo fi in fields)
            {
                if (fi.Name == $"{typeof(T).Name}s")
                {
                    return fi.GetValue(null) as List<T>;
                }
                    
            }

            return null;
        }

        public T GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void Create(T obj)
        {
            var list = GetAll();
            list.Add(obj);

            SaveList(list);
        }

        public void Update(T obj)
        {
            var singleObject = GetById(obj.Id);

            if (singleObject != null)
            {
                var list = GetAll();
                list.Remove(singleObject);
                list.Add(obj);

                SaveList(list);
            }
        }

        public void Delete(T obj)
        {
            var singleObject = GetById(obj.Id);

            if (singleObject != null)
            {
                var list = GetAll();
                list.Remove(singleObject);

                SaveList(list);
            }
        }

        private void SaveList(List<T> list)
        {
            Type t = typeof(Storage);
            FieldInfo[] fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach (FieldInfo fi in fields)
            {
                if (fi.Name == $"{typeof(T).Name}s")
                {
                    fi.SetValue(null, list);
                }
            }
        }*/
        #endregion

        private readonly PizzaSystemDbContext _dbContext;

        public Repository(PizzaSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> GetAll(Func<IQueryable<T>, IQueryable<T>> func = null)
        {
            var dbSet = _dbContext.Set<T>();
            if (func != null)
            {
                return func(dbSet).ToList();
            }
            return dbSet.ToList();
        }

        public T GetById(int id, Func<IQueryable<T>, IQueryable<T>> func = null)
        {
            var dbSet = _dbContext.Set<T>();
            if (func != null)
            {
                return func(dbSet).FirstOrDefault(x => x.Id == id);
            }
            return dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Create(T obj)
        {
            _dbContext.Set<T>().Add(obj);
            _dbContext.SaveChanges();
        }

        public void Update(T obj)
        {
            _dbContext.Set<T>().Update(obj);
            _dbContext.SaveChanges();
        }

        public void Delete(T obj)
        {
            _dbContext.Set<T>().Remove(obj);
            _dbContext.SaveChanges();
        }
    }
}
