using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtoModels
{
    public class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }

        public User(string name, string address, string phone)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }

        public User()
        {
            
        }
    }
}
