using System.Collections.Generic;
using System.Linq;
using DtoModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;
namespace Mappers
{
    public static class PizzaMapper
    {
        public static PizzaViewModel ToViewModel(this Pizza pizza)
        {
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                Prices = new Dictionary<ViewModels.SizeEnum, int>
                {
                    { ViewModels.SizeEnum.Small, pizza.GetPrice(DtoModels.SizeEnum.Small) },
                    { ViewModels.SizeEnum.Medium, pizza.GetPrice(DtoModels.SizeEnum.Medium) },
                    { ViewModels.SizeEnum.Large, pizza.GetPrice(DtoModels.SizeEnum.Large) }
                },
                Ingredients = pizza.PizzaIngredients.Select(x => x.Ingredient).Select(x => x.ToViewModel()).ToList()
            };
        }

        public static CreatePizzaViewModel ToCreateModel(this Pizza pizza)
        {
            return new CreatePizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Description = pizza.Description,
                BasePrice = pizza.GetPrice(DtoModels.SizeEnum.Small),
                AllIngredients = new List<SelectListItem>(),
                SelectedIngredients = pizza.PizzaIngredients.Select(x => x.Ingredient).Select(x => x.Id).ToList()
            };
        }
    }
}
