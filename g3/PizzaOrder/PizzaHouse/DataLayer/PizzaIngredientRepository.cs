using System.Linq;
using DtoModels;

namespace DataLayer
{
    public class PizzaIngredientRepository : IPizzaIngredientRepository
    {
        private readonly PizzaSystemDbContext _dbContext;

        public PizzaIngredientRepository(PizzaSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void RemoveAllPizzaIngredients(int pizzaId)
        {
            var allIngredients = _dbContext.PizzaIngredients.Where(x => x.PizzaId == pizzaId);
            _dbContext.RemoveRange(allIngredients);
            _dbContext.SaveChanges();
        }
    }
}
