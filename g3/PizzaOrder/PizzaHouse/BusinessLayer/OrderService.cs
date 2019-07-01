using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DtoModels;
using Mappers;
using Microsoft.EntityFrameworkCore;
using ViewModels;

namespace BusinessLayer
{
    public class OrderService : IOrderService
    {
        private readonly IPizzaService _pizzaService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<User> _userRepository;

        public OrderService(IPizzaService pizzaService, IRepository<Order> orderRepository, IRepository<User> userRepository)
        {
            _pizzaService = pizzaService;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public OrderViewModel GetEmptyOrder()
        {
            var order = new OrderViewModel();
            var menu = _pizzaService.GetMenu();

            foreach (var pizza in menu.PizzasList)
            {
                order.OrderItems.Add(new OrderItemViewModel
                {
                    Pizza = pizza,
                    Size = ViewModels.SizeEnum.Small,
                    Quantity = 0
                });

                order.OrderItems.Add(new OrderItemViewModel
                {
                    Pizza = pizza,
                    Size = ViewModels.SizeEnum.Medium,
                    Quantity = 0
                });

                order.OrderItems.Add(new OrderItemViewModel
                {
                    Pizza = pizza,
                    Size = ViewModels.SizeEnum.Large,
                    Quantity = 0
                });
            }

            return order;
        }

        public void CreateOrder(OrderViewModel model)
        {
            var user = _userRepository.GetAll(x =>
                    x.Where(y => y.Name == model.Name && y.Address == model.Address && y.Phone == model.Phone))
                .FirstOrDefault();

            if (user == null)
            {
                var newUser = new User(model.Name, model.Address, model.Phone);
                _userRepository.Create(newUser);

                user = _userRepository.GetAll(x =>
                        x.Where(y => y.Name == model.Name && y.Address == model.Address && y.Phone == model.Phone))
                    .FirstOrDefault();
            }

            var orderItems = new List<OrderItem>();
            foreach (var orderItem in model.OrderItems.Where(x => x.Quantity > 0))
            {
                var item = new OrderItem
                {
                    PizzaId = orderItem.Pizza.Id,
                    Size = (DtoModels.SizeEnum) (int) orderItem.Size,
                    Quantity = orderItem.Quantity
                };

                orderItems.Add(item);
            }

            var order =  new Order
            {
                User = user,
                OrderItems = orderItems
            };

            _orderRepository.Create(order);
        }

        public List<OrderViewModel> GetAllOrders()
        {
            var allOrders = _orderRepository
                .GetAll(x => x.Include(y => y.User).Include(y => y.OrderItems).ThenInclude(y => y.Pizza)).ToList();

            return allOrders.Select(x => x.ToViewModel()).ToList();
        }
    }
}
