using DtoModels;
using ViewModels;

namespace Mappers
{
    public static class IngredientMapper
    {
        public static IngredientViewModel ToViewModel(this Ingredient ingredient)
        {
            return new IngredientViewModel
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Allergens = ingredient.Allergens
            };
        }
    }
}
