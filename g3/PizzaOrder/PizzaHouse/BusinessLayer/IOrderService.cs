using System.Collections.Generic;
using ViewModels;

namespace BusinessLayer
{
    public interface IOrderService
    {
        OrderViewModel GetEmptyOrder();
        void CreateOrder(OrderViewModel model);
        List<OrderViewModel> GetAllOrders();
    }
}
