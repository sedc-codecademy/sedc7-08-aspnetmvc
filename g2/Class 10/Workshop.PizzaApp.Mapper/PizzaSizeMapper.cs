using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Data.Model;
using Workshop.PizzaApp.Model;

namespace Workshop.PizzaApp.Mapper
{
    public static class PizzaSizeMapper
    {
        public static PizzaSizeViewModel ToViewModel(this PizzaSizeModel model)
        {
            return new PizzaSizeViewModel
            {
                PizzaSizeId = model.PizzaSizeId,
                PizzaId = model.PizzaId,
                PizzaName = model.Pizza.Name,
                SizeId = model.SizeId,
                SizeName = model.Size.Name,
                Price = model.Price
            };
        }

        public static List<PizzaSizeViewModel> ToViewModelList(this List<PizzaSizeModel> models)
        {
            var viewModels = new List<PizzaSizeViewModel>();

            foreach (var model in models)
            {
                viewModels.Add(
                    new PizzaSizeViewModel
                    {
                        PizzaSizeId = model.PizzaSizeId,
                        SizeId = model.SizeId,
                        SizeName = model.Size.Name,
                        PizzaId = model.PizzaId,
                        PizzaName = model.Pizza.Name,
                        Price = model.Price
                    });
            }

            return viewModels;
        }

        public static PizzaSizeModel ToModel(this PizzaSizeViewModel model)
        {
            return new PizzaSizeModel
            {
                PizzaSizeId = model.PizzaSizeId ?? 0,
                PizzaId = model.PizzaId,
                SizeId = model.SizeId,
                Price = model.Price
            };
        }
    }
}
