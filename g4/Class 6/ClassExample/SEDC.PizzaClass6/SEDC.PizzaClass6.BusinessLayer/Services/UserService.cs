using System.Collections.Generic;
using SEDC.PizzaClass6.BusinessLayer.Interfaces;
using SEDC.PizzaClass6.BusinessLayer.ViewModels;
using SEDC.PizzaClass6.DataLayer.Interfaces;
using SEDC.PizzaClass6.DomainModels.Models;

namespace SEDC.PizzaClass6.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICollection<DtoUser> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return MapUsersToDtoUsers(users);
        }

        private ICollection<DtoUser> MapUsersToDtoUsers(ICollection<User> users)
        {
            List<DtoUser> dtoUsers = new List<DtoUser>();
            foreach (var user in users)
            {
                dtoUsers.Add(new DtoUser(user));
            }
            return dtoUsers;
        }
    }
}
