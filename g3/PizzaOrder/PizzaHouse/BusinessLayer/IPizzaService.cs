using System.Collections.Generic;
using DtoModels;
using ViewModels;

namespace BusinessLayer
{
    public interface IPizzaService
    {
        MenuViewModel GetMenu();
        void CreatePizza(CreatePizzaViewModel pizza);
        PizzaViewModel GetPizza(int id);
        CreatePizzaViewModel GetEmptyPizza();
        CreatePizzaViewModel GetPizzaUpdateModel(int id);
        void UpdatePizza(CreatePizzaViewModel pizza);
    }
}
