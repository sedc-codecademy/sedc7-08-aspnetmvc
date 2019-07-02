using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Model;

namespace Workshop.PizzaApp.Service.Interfaces
{
    public interface ISizeManagementService
    {
        List<SizeViewModel> GetAllSizes();

        SizeViewModel GetSizeById(int sizeId);

        void AddSize(SizeViewModel size);

        void UpdateSize(SizeViewModel size);

        void DeleteSize(int sizeId);
    }
}
