using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtoModels
{
    public class Ingredient : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public ICollection<IngredientAllergen> IngredientAllergens { get; set; }
        public ICollection<PizzaIngredient> PizzaIngredients { get; set; }

        public Ingredient(string name)
        {
            Name = name;
            //IngredientAllergens = new List<IngredientAllergen>();
            //PizzaIngredients = new List<PizzaIngredient>();
        }

        public Ingredient()
        {
            
        }
    }
}
