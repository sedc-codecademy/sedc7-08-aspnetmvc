using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Data.Model;
using Workshop.PizzaApp.Model;

namespace Workshop.PizzaApp.Mapper
{
    public static class SizeMapper
    {
        public static SizeViewModel ToViewModel(this SizeModel model)
        {
            return new SizeViewModel
            {
                SizeId = model.SizeId,
                Name = model.Name,
                Diameter = model.Diameter
            };
        }

        public static List<SizeViewModel> ToViewModelList(this List<SizeModel> models)
        {
            var viewModels = new List<SizeViewModel>();

            foreach (var model in models)
            {
                viewModels.Add(
                    new SizeViewModel
                    {
                        SizeId = model.SizeId,
                        Name = model.Name,
                        Diameter = model.Diameter
                    });
            }

            return viewModels;
        }

        public static SizeModel ToModel(this SizeViewModel model)
        {
            return new SizeModel
            {
                SizeId = model.SizeId ?? 0,
                Name = model.Name,
                Diameter = model.Diameter
            };
        }
    }
}
