using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEDC.PizzApp.DataAccess.Repositories;
using SEDC.PizzApp.Domain;

namespace SEDC.PizzApp.Services.Services
{
    public class PizzaOrderService : IPizzaOrderService
    {
        private IRepository<Order> _orderRepository;
        private IRepository<Pizza> _pizzaRepository;
        public PizzaOrderService(IRepository<Order> orderRepo, 
            IRepository<Pizza> pizzaRepo)
        {
            _orderRepository = orderRepo;
            _pizzaRepository = pizzaRepo;
        }
        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order GetLastOrder()
        {
            List<Order> orders = _orderRepository.GetAll();
            return orders[orders.Count - 1];
        }

        public List<Pizza> GetMenu()
        {
            List<Pizza> menu = _pizzaRepository.GetAll()
                .GroupBy(x => x.Name)
                .Select(x => x.First())
                .ToList();
            return menu;
        }

        public string GetMostPopularPizza()
        {
            // We get all orders
            List<Order> orders = _orderRepository.GetAll();
            // Flattening ( all pizzas from all orders )
            List<Pizza> pizzas = orders
                .SelectMany(x => x.Pizzas)
                .ToList();
            string mostPopularPizza = pizzas
                .GroupBy(x => x.Name) // We group it by name ( 2 peperoni, 3 kapri, 1 margarita, 1 siciliana )
                .OrderByDescending(x => x.Count()) // Order them by  descending so that the first is the one that has the most pizzas ( 3 kapri, 2 peperoni, 1 margarita, 1 siciliana )
                .FirstOrDefault() // Takes the first from the group ( 3 kapri pizzas )
                .Select(x => x.Name) // Select only the names ( Kapri, Kapri, Kapri )
                .FirstOrDefault(); // Select the first ( Kapri )
            return mostPopularPizza;
        }

        public Order GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public int GetOrderCount()
        {
            return _orderRepository.GetAll().Count;
        }

        public void MakeNewOrder(Order order)
        {
            // validation, proverki itn itn
            _orderRepository.Insert(order);
        }
        public Pizza GetPizzaFromMenu(string name, PizzaSize size)
        {
            List<Pizza> menu = _pizzaRepository.GetAll();
            return menu.Where(x => x.Name == name && x.Size == size).FirstOrDefault();
        }
    }
}
