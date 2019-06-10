using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.IRepositories
{
    public interface IUserRepository
    {
        User Get(int id);
        IEnumerable<User> GetAll();
        User Add(User user);
        User Update(User user);
        User Delete(int id);
    }
}
