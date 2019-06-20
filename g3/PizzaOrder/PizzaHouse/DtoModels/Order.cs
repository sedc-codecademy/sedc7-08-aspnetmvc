using System.Collections.Generic;

namespace DtoModels
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }

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
