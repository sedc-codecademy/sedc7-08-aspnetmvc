using System.Collections.Generic;

namespace ViewModels
{
    public class IngredientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Allergens { get; set; }
    }
}
