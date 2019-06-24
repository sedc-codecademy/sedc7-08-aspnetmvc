namespace Sedc.Filters.WebApp.Models
{
    public class Pizza
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Style { get; set; }
        public string Ingredients { get; set; }
        public string Allergens { get; set; }
        public bool IsVegan { get; set; }
        public bool IsFasting { get; set; }
        public bool IsHalal { get; set; }
        public bool IsKosher { get; set; }
        public double Price { get; set; }
    }
}
