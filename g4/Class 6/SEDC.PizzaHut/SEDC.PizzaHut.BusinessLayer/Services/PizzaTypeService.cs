using SEDC.PizzaHut.BusinessLayer.Interfaces;
using SEDC.PizzaHut.DataLayer.Interfaces;
using SEDC.PizzaHut.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.PizzaHut.BusinessLayer.Services
{
    public class PizzaTypeService : IPizzaTypeService
    {
        private readonly IPizzaTypeRepository _pizzaTypeRepository;

        public PizzaTypeService(IPizzaTypeRepository pizzaTypeRepository)
        {
            _pizzaTypeRepository = pizzaTypeRepository;
        }

        public List<PizzaType> GetAll()
        {
            var result = _pizzaTypeRepository.GetAll().ToList();
            return result;
        }
    }
}
