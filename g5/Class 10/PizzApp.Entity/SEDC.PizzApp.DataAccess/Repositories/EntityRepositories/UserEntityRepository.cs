using SEDC.PizzApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzApp.DataAccess.Repositories.EntityRepositories
{
    public class UserEntityRepository : IRepository<User>
    {
        private PizzaDbContext _context;
        public UserEntityRepository(PizzaDbContext context)
        {
            _context = context;
        }
        public void DeleteById(int id)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null) _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(User entity)
        {
            _context.Users.Add(entity);
            int id = _context.SaveChanges();
            return id;
        }

        public void Update(User entity)
        {
            User user = _context.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (user != null)
            {
                entity.Id = user.Id;
                _context.Users.Update(entity);
            }
        }
    }
}
