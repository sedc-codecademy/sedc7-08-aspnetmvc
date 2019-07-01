using SEDC.PizzaHut.BusinessLayer.Interfaces;
using SEDC.PizzaHut.BusinessLayer.ViewModels;
using SEDC.PizzaHut.DataLayer.Interfaces;
using SEDC.PizzaHut.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaHut.BusinessLayer.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IPizzaTypeRepository _pizzaTypeRepository;

        public PizzaService(IPizzaRepository pizzaRepository,
            IPizzaTypeRepository pizzaTypeRepository)
        {
            _pizzaRepository = pizzaRepository;
            _pizzaTypeRepository = pizzaTypeRepository;
        }

        public int AddPizza(CreatePizzaViewModel pizza)
        {
            var newPizza = new Pizza();
            newPizza.Name = pizza.Name;
            newPizza.PizzaTypeId = pizza.PizzaTypeId;
            newPizza.Price = pizza.Price;
            newPizza.Size = pizza.Size;

            var added = _pizzaRepository.Insert(newPizza);
            return added;
        }

        public int EditPizza(EditPizzaViewModel pizza)
        {
            var newPizza = new Pizza();
            newPizza.Id = pizza.Id;
            newPizza.Name = pizza.Name;
            newPizza.PizzaTypeId = pizza.PizzaTypeId;
            newPizza.Price = pizza.Price;
            newPizza.Size = pizza.Size;
            new PizzaViewModel(newPizza);
            var modified = _pizzaRepository.Update(newPizza);
            return modified;
        }

        public List<PizzaViewModel> GetAll()
        {
            var pizzas = _pizzaRepository.GetAll().ToList();

            List<PizzaViewModel> result = new List<PizzaViewModel>();
            foreach (var pizza in pizzas)
            {
                result.Add(new PizzaViewModel(pizza));
            }
            
            return result;
        }

        public PizzaViewModel GetById(int id)
        {
            var pizza = _pizzaRepository.Get(id);
            var pizzaView = new PizzaViewModel(pizza);
            return pizzaView;
        }

        public int RemovePizza(int id)
        {
            var removed = _pizzaRepository.Delete(id);
            return removed;
        }
    }
}
