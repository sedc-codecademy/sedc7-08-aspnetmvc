using System.Collections.Generic;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain;

namespace SEDC.PizzaApp.Services
{
    public class PizzaService : IService
    {
        private readonly IRepository<Pizza> _pizzaRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }
        
        public List<Pizza> GetAllPizzas()
        {
            return _pizzaRepository.GetAll();
        }

        public Pizza GetPizzaById(int id)
        {
            return _pizzaRepository.GetById(id);
        }

        public void CreatePizza(Pizza pizza)
        {
            _pizzaRepository.Create(pizza);
        }
        
        public void UpdatePizza(Pizza pizza)
        {
            _pizzaRepository.Update(pizza);
        }


        public void DeletePizzaById(int id)
        {
            _pizzaRepository.Delete(id);
        }

    }
}
