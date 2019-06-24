using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtoModels
{
    public class Order : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            
        }

        public int TotalPrice
        {
            get
            {
                int totalSum = 0;
                foreach (var item in OrderItems)
                {
                    totalSum += item.Pizza.GetPrice(item.Size) * item.Quantity;
                }
                return totalSum;
            }
        }
    }
}
