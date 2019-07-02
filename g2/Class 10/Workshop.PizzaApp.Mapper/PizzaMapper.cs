using System;
using System.Collections.Generic;
using System.Text;
using Workshop.PizzaApp.Data.Model;
using Workshop.PizzaApp.Model;

namespace Workshop.PizzaApp.Mapper
{
    public static class PizzaMapper
    {
        public static PizzaViewModel ToViewModel(this PizzaModel model)
        {
            return new PizzaViewModel
            {
                PizzaId = model.PizzaId,
                Name = model.Name,
                Description = model.Description
            };
        }

        public static List<PizzaViewModel> ToViewModelList(this List<PizzaModel> models)
        {
            var viewModels = new List<PizzaViewModel>();

            foreach (var model in models)
            {
                viewModels.Add(
                    new PizzaViewModel
                    {
                        PizzaId = model.PizzaId,
                        Name = model.Name,
                        Description = model.Description
                    });
            }

            return viewModels;
        }

        public static PizzaModel ToModel(this PizzaViewModel model)
        {
            return new PizzaModel
            {
                PizzaId = model.PizzaId ?? 0,
                Name = model.Name,
                Description = model.Description
            };
        }
    }
}
