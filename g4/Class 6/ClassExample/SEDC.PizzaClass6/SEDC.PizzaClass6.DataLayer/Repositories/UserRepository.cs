using SEDC.PizzaClass6.DataLayer.Interfaces;
using SEDC.PizzaClass6.DomainModels.Models;

namespace SEDC.PizzaClass6.DataLayer.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(UserContext context)
            : base(context)
        {
        }
    }
}
