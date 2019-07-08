using ViewModels;

namespace BusinessLayer
{
    public interface IUserService
    {
        UserViewModel GetUser(string email, string password);
        UserViewModel GetUserByEmail(string email);
    }
}
