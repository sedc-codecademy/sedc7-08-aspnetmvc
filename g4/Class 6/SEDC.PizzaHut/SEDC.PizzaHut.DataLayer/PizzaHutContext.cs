using Microsoft.EntityFrameworkCore;
using SEDC.PizzaHut.Domain.Models;

namespace SEDC.PizzaHut.DataLayer
{
    public class PizzaHutContext : DbContext
    {
        public PizzaHutContext(DbContextOptions<PizzaHutContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PizzaType>()
                .HasData(
                new PizzaType { Id = 1, Name = "Capri", Description = "dough, ham, mashrums" },
                new PizzaType { Id = 2, Name = "Quatro", Description = "dough, cheese, mashrums" },
                new PizzaType { Id = 3, Name = "Vege", Description = "dough, vegetables, mashrums" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
