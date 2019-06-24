using SEDC.PizzApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzApp.Services.Services
{
    public interface IPizzaOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        void MakeNewOrder(Order order);
        int GetOrderCount();
        List<Pizza> GetMenu();
        Order GetLastOrder();
        string GetMostPopularPizza();
        Pizza GetPizzaFromMenu(string name, PizzaSize size);
    }
}
