namespace SEDC.PizzaClass6.DomainModels.Models
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }
    }
}
