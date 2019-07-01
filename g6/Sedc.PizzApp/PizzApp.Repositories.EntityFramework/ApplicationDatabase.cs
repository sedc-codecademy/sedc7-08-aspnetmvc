using Microsoft.EntityFrameworkCore;
using PizzApp.Models;

namespace PizzApp.Repositories.EntityFramework
{
    public class ApplicationDatabase : DbContext
    {
        public ApplicationDatabase(
            DbContextOptions<ApplicationDatabase> options)
            : base(options)
        {
            Database.EnsureCreated();
            //base.Database.BeginTransaction();
            //base.Database.RollbackTransaction();
            //base.Database.CommitTransaction();
        }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaPrice> PizzaPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaPrice>()
                .HasKey(x => new
                {
                    x.PizzaId,
                    x.Size
                });
        }
    }
}
