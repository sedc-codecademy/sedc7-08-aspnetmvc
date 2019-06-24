using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace BusinessLayer
{
    public interface IIngredientService
    {
        List<IngredientViewModel> GetAllIngredients();
        List<SelectListItem> GetIngredientsSelectList();
    }
}
