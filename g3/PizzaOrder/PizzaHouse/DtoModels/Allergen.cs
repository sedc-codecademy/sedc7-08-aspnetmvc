using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DtoModels
{
    public class Allergen : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<IngredientAllergen> IngredientAllergens { get; set; }

        public Allergen(string name)
        {
            Name = name;
        }

        public Allergen()
        {
            
        }
    }
}
