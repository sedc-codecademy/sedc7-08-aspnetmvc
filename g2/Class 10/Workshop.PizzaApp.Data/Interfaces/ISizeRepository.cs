using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Data.Model;

namespace Workshop.PizzaApp.Data.Interfaces
{
    public interface ISizeRepository
    {
        List<SizeModel> GetAllSizes();
        SizeModel GetSizeById(int sizeId);
        void AddSize(SizeModel size);
        void EditSize(SizeModel size);
        void DeleteSize(int sizeId);
    }
}
