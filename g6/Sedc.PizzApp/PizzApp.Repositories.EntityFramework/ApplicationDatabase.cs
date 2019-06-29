using Microsoft.EntityFrameworkCore;
using PizzApp.Models;

namespace PizzApp.Repositories.EntityFramework
{
    public class ApplicationDatabase: DbContext
    {
        public ApplicationDatabase(
            DbContextOptions<ApplicationDatabase> options)
            :base(options)
        {
            //0Database.EnsureCreated();
            //base.Database.BeginTransaction();
            //base.Database.RollbackTransaction();
            //base.Database.CommitTransaction();
        }
        public DbSet<Pizza> Pizzas { get; set; }
    }
}
