using PizzaHouse.Models;
using PizzaHouse.ViewModels;

namespace PizzaHouse.Services
{
    public interface IPizzaService
    {
        Menu GetMenu();
        void CreatePizza(PizzaViewModel pizza);
    }
}
