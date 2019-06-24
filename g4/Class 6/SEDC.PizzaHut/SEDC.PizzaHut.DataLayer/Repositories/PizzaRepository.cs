using SEDC.PizzaHut.DataLayer.Interfaces;
using SEDC.PizzaHut.Domain.Models;

namespace SEDC.PizzaHut.DataLayer.Repositories
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
    {
        public PizzaRepository(PizzaHutContext context)
            :base(context)
        {
        }
    }
}
