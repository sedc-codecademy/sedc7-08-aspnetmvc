using SEDC.PizzaClass6.DomainModels.Models;

namespace SEDC.PizzaClass6.BusinessLayer.ViewModels
{
    public class DtoUser
    {
        public DtoUser(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Address = user.Address;
            City = user.City;
            Phone = user.Phone;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }
    }
}
