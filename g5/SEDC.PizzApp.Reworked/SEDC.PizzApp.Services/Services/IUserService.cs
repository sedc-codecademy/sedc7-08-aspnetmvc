using SEDC.PizzApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzApp.Services.Services
{
    public interface IUserService
    {
        User GetUserById(int id);
        int AddNewUser(User entity);
        string GetLastUserName();
        void GiveFeedback(Feedback feedback);
        List<Feedback> GetFeedback(int numberOfFeedbackUnits);
    }
}
