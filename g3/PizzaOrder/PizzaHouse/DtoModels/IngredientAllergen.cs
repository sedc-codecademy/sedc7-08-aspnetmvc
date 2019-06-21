namespace DtoModels
{
    public class IngredientAllergen
    {
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public Allergen Allergen { get; set; }
        public int AllergenId { get; set; }
    }
}
