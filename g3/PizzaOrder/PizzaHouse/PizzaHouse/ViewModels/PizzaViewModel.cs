using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaHouse.Data;

namespace PizzaHouse.ViewModels
{
    public class PizzaViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Please insert more than 3 char")]
        [DisplayName("Pizza Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Please select ingredients")]
        [MinLength(1)]
        public List<int> SelectedIngredients { get; set; }

        [Required(ErrorMessage = "Please insert base price for the pizza")]
        [DisplayName("Default pizza price")]
        [Range(typeof(int), "100", "500")]
        public int BasePrice { get; set; }

        public List<SelectListItem> AllIngredients { get; set; }

        public PizzaViewModel()
        {
            SelectedIngredients = new List<int>();
            AllIngredients = new List<SelectListItem>();

            foreach (var ingredient in Storage.Ingredients)
            {
                AllIngredients.Add(new SelectListItem
                {
                    Text = ingredient.Name,
                    Value = ingredient.Id.ToString()
                });
            }
        }
    }
}
