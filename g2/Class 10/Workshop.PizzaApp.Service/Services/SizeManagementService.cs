using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Data.Interfaces;
using Workshop.PizzaApp.Mapper;
using Workshop.PizzaApp.Model;
using Workshop.PizzaApp.Service.Interfaces;

namespace Workshop.PizzaApp.Service.Services
{
    public class SizeManagementService : ISizeManagementService
    {
        private ISizeRepository _sizeRepository;

        public SizeManagementService(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public void AddSize(SizeViewModel size)
        {
            _sizeRepository.AddSize(size.ToModel());
        }

        public void DeleteSize(int sizeId)
        {
            _sizeRepository.DeleteSize(sizeId);
        }

        public List<SizeViewModel> GetAllSizes()
        {
            return _sizeRepository.GetAllSizes().ToViewModelList();
        }

        public SizeViewModel GetSizeById(int sizeId)
        {
            return _sizeRepository.GetSizeById(sizeId).ToViewModel();
        }

        public void UpdateSize(SizeViewModel size)
        {
            _sizeRepository.EditSize(size.ToModel());
        }
    }
}
