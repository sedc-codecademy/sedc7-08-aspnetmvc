using System.Collections.Generic;
using System.Linq;
using DataLayer;
using DtoModels;
using Mappers;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewModels;

namespace BusinessLayer
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepository<Ingredient> _ingredientRepository;

        public IngredientService(IRepository<Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public List<IngredientViewModel> GetAllIngredients()
        {
            var allIngredients = _ingredientRepository.GetAll().Select(x => x.ToViewModel()).ToList();
            return allIngredients;
        }

        public List<SelectListItem> GetIngredientsSelectList()
        {
            return _ingredientRepository.GetAll().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
        }
    }
}
