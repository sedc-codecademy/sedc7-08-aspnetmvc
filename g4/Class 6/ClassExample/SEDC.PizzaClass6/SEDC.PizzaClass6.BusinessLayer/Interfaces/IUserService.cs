using SEDC.PizzaClass6.BusinessLayer.ViewModels;
using System.Collections.Generic;

namespace SEDC.PizzaClass6.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        ICollection<DtoUser> GetAllUsers();
    }
}
