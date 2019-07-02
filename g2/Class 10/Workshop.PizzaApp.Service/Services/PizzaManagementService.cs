using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Data.Interfaces;
using Workshop.PizzaApp.Mapper;
using Workshop.PizzaApp.Model;
using Workshop.PizzaApp.Service.Interfaces;

namespace Workshop.PizzaApp.Service.Services
{
    public class PizzaManagementService : IPizzaManagementService
    {
        private IPizzaRepository _pizzaRepository;

        public PizzaManagementService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public void AddPizza(PizzaViewModel pizza)
        {
            _pizzaRepository.AddPizza(pizza.ToModel());
        }

        public void DeletePizza(int pizzaId)
        {
            _pizzaRepository.DeletePizza(pizzaId);
        }

        public List<PizzaViewModel> GetAllPizzas()
        {
            var pizzas = _pizzaRepository.GetAllPizzas();
            return pizzas.ToViewModelList();
        }

        public PizzaViewModel GetPizzaById(int pizzaId)
        {
            return _pizzaRepository.GetPizzaById(pizzaId).ToViewModel();
        }

        public void UpdatePizza(PizzaViewModel pizza)
        {
            _pizzaRepository.EditPizza(pizza.ToModel());
        }
    }
}
