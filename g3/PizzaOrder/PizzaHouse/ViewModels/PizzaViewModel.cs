using System.Collections.Generic;

namespace ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
        public Dictionary<SizeEnum, int> Prices { get; set; }
    }
}
