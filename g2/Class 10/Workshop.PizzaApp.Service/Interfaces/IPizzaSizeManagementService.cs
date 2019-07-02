using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Model;

namespace Workshop.PizzaApp.Service.Interfaces
{
    public interface IPizzaSizeManagementService
    {
        List<PizzaSizeViewModel> GetAllPizzaSizes();

        PizzaSizeViewModel GetPizzaSizeById(int pizzaSizeId);

        void AddPizzaSize(PizzaSizeViewModel pizzaSize);

        void UpdatePizzaSizePrice(PizzaSizeViewModel pizzaSize);

        void DeletePizzaSize(int pizzaSizeId);
    }
}
