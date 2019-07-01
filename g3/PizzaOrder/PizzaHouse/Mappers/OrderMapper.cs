using System.Collections.Generic;
using DtoModels;
using ViewModels;

namespace Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToViewModel(this Order order)
        {
            var model = new OrderViewModel
            {
                Id = order.Id,
                Name = order.User.Name,
                Phone = order.User.Phone,
                Address = order.User.Address,
                OrderItems = new List<OrderItemViewModel>()
            };

            foreach (var item in order.OrderItems)
            {
                var orderItem = new OrderItemViewModel
                {
                    Size = (ViewModels.SizeEnum) (int) item.Size,
                    Quantity = item.Quantity,
                    Pizza = new PizzaViewModel
                    {
                        Id = item.Pizza.Id,
                        Name = item.Pizza.Name,
                        Description = item.Pizza.Description
                    }
                };

                model.OrderItems.Add(orderItem);
            }

            return model;
        }
}
}
