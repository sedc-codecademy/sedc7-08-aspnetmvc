using SEDC.PizzApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SEDC.PizzApp.DataAccess.Repositories.CacheRepositories
{
    public class UserRepository : IRepository<User>
    {
        public void DeleteById(int id)
        {
            // If return is bool -> true is successfull delete and false is not
            // If return is int -> the id is successfull delete and -1 is not
            User user = CacheDb.Users.FirstOrDefault(x => x.Id == id);
            if (user != null) CacheDb.Users.Remove(user);
        }

        public List<User> GetAll()
        {
            return CacheDb.Users;
        }

        public User GetById(int id)
        {
            return CacheDb.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            CacheDb.UserId++;
            entity.Id = CacheDb.UserId;
            CacheDb.Users.Add(entity);
            return entity.Id;
        }

        public void Update(User entity)
        {
            User user = CacheDb.Users.FirstOrDefault(x => x.Id == entity.Id);
            if(user != null)
            {
                int index = CacheDb.Users.IndexOf(user);
                CacheDb.Users[index] = entity;
            }
        }
    }
}
