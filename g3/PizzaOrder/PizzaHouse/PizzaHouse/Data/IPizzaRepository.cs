using PizzaHouse.Models;

namespace PizzaHouse.Data
{
    public interface IPizzaRepository
    {
        Menu GetMenu();
        void Create(Pizza pizza);
    }
}
