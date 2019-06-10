using PizzaHut.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.MockRepositories
{
    public class MockUserRepository : IUserRepository
    {
        List<User> users;
        public MockUserRepository()
        {
            users = new List<User>()
            { 
                new User{ID=1, Name="Bojan", Address="Partizanska", City="Skopje", Email="bojan@abc.com",Phone="078123123"},
                new User{ID=2, Name="Viktor", Address="Vodnjanska", City="Stip", Email="viktor@abc.com",Phone="078123123"},
                new User{ID=3, Name="Dejan", Address="R. Luxemburg", City="Bitola", Email="dejan@abc.com",Phone="078123123"},
            };
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User Get(int id)
        {
            return GetAll().FirstOrDefault(u => u.ID == id);
        }
        
        public User Add(User user)
        {
            int nextId = 0;
            if (users.ToList().Count > 0)
                nextId = users.ToList().Count + 1;
            user.ID = nextId;
            users.Add(user);
            return user;
        }

        public User Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        public User Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
