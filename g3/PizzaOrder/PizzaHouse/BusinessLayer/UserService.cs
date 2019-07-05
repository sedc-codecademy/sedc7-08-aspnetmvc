using System;
using System.Linq;
using DataLayer;
using DtoModels;
using ViewModels;

namespace BusinessLayer
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public UserViewModel GetUser(string email, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user == null)
                return null;

            return new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Name = user.Name
            };
        }

        public UserViewModel GetUserByEmail(string email)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Email == email);

            if (user == null)
                throw new Exception("User does not exist.");

            return new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Name = user.Name
            };
        }
    }
}
