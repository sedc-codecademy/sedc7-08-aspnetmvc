using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Data.Interfaces;
using Workshop.PizzaApp.Mapper;
using Workshop.PizzaApp.Model;
using Workshop.PizzaApp.Service.Interfaces;

namespace Workshop.PizzaApp.Service.Services
{
    public class PizzaSizeManagementService : IPizzaSizeManagementService
    {
        private IPizzaSizeRepository _pizzaSizeRepository;

        public PizzaSizeManagementService(IPizzaSizeRepository pizzaSizeRepository)
        {
            _pizzaSizeRepository = pizzaSizeRepository;
        }

        public void AddPizzaSize(PizzaSizeViewModel pizzaSize)
        {
            _pizzaSizeRepository.AddPizzaSize(pizzaSize.ToModel());
        }

        public void DeletePizzaSize(int pizzaSizeId)
        {
            _pizzaSizeRepository.DeletePizzaSize(pizzaSizeId);
        }

        public List<PizzaSizeViewModel> GetAllPizzaSizes()
        {
            return _pizzaSizeRepository.GetAllPizzaSizes().ToViewModelList();
        }

        public PizzaSizeViewModel GetPizzaSizeById(int pizzaSizeId)
        {
            return _pizzaSizeRepository.GetPizzaSizeById(pizzaSizeId).ToViewModel();
        }

        public void UpdatePizzaSizePrice(PizzaSizeViewModel pizzaSize)
        {
            _pizzaSizeRepository.EditPizzaSizePrice(pizzaSize.ToModel());
        }
    }
}
