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
        private IRepository<Feedback> _feedbackRepository;
        public UserService(IRepository<User> userRepository, IRepository<Feedback> feedbackRepository)
        {
            _userRepository = userRepository;
            _feedbackRepository = feedbackRepository;
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
        public void GiveFeedback(Feedback feedback)
        {
            _feedbackRepository.Insert(feedback);
        }
        public List<Feedback> GetFeedback(int numberOfFeedbackUnits)
        {
            return _feedbackRepository.GetAll().GetRange(0, numberOfFeedbackUnits);
        }
    }
}
