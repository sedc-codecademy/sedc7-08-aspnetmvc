using PizzaHut.Models.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut.Models.MockRepositories
{
    public class MockPizzaTypeRepository : IPizzaTypeRepository
    {
        List<PizzaType> pizzaTypes;
        public MockPizzaTypeRepository()
        {
            pizzaTypes = new List<PizzaType>()
            {
                new PizzaType{ID = 1, Name="Capri", Description="dough, ham, mashrums"},
                new PizzaType{ID = 2, Name="Quatro", Description="dough, cheese, mashrums"},
                new PizzaType{ID = 3, Name="Vege", Description="dough, vegetables, mashrums"}
            };
        }

        public IEnumerable<PizzaType> GetAll()
        {
            return pizzaTypes;
        }

        public PizzaType Add(PizzaType pizzaType)
        {
            throw new NotImplementedException();
        }

        public PizzaType Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PizzaType Get(int id)
        {
            throw new NotImplementedException();
        }               

        public PizzaType Update(PizzaType PizzaTypeChanges)
        {
            throw new NotImplementedException();
        }
    }
}
