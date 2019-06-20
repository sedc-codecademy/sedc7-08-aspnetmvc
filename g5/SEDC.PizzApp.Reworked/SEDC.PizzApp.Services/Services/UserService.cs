using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEDC.PizzApp.DataAccess.Repositories;
using SEDC.PizzApp.Domain;

namespace SEDC.PizzApp.Services.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public int AddNewUser(User entity)
        {
            return _userRepository.Insert(entity);
        }

        public string GetLastUserName()
        {
            return _userRepository.GetAll().LastOrDefault().FirstName;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
