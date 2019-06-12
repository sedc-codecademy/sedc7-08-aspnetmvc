using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.IRepositories
{
    public interface IPizzaRepository
    {
        Pizza Get(int id);
        IEnumerable<Pizza> GetAll();
        Pizza Add(Pizza pizza);
        Pizza Update(Pizza pizza);
        Pizza Delete(int id);

    }
}
