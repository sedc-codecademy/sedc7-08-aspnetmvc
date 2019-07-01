using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Data.Model;

namespace Workshop.PizzaApp.Data.Interfaces
{
    public interface IPizzaSizeRepository
    {
        List<PizzaSizeModel> GetAllPizzaSizes();
        PizzaSizeModel GetPizzaSizeById(int pizzaSizeId);
        void AddPizzaSize(PizzaSizeModel pizzaSize);
        void EditPizzaSizePrice(PizzaSizeModel pizzaSize);
        void DeletePizzaSize(int pizzaSizeId);
    }
}
