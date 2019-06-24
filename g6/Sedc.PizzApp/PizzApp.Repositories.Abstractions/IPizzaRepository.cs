using PizzApp.Models;
using System.Collections.Generic;

namespace PizzApp.Repositories.Abstractions
{
    public interface IPizzaRepository
    {
        List<Pizza> GetAllPizzas();
    }
}
