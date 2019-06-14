using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PizzaHouse.Models;

namespace PizzaHouse.Data
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        public List<T> GetAll()
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
        }

    }
}
