using System.Collections.Generic;

namespace ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }

        public OrderViewModel()
        {
            OrderItems = new List<OrderItemViewModel>();
        }
    }
}
