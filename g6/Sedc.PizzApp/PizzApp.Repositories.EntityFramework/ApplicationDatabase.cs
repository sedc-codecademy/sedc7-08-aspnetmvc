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

        //private void PrintItems(params int[] items)
        //{
        //    foreach (var item in items)
        //    {
        //        System.Console.WriteLine(item);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Pizza>()
            //    //.HasKey(x => x.Id);
            //    .HasKey("Id")
            //    .HasName("Primary Key");

            //modelBuilder.Entity<PizzaPrice>()
            //    .HasOne(pizzaPrice => pizzaPrice.Pizza)
            //    .WithMany(pizza => pizza.PizzaPrices)
            //    .HasForeignKey(pizzaPrice => pizzaPrice.PizzaId);

            //modelBuilder.Entity<Pizza>()
            //    .HasMany(pizza => pizza.PizzaPrices)
            //    .WithOne(pizzaPrice => pizzaPrice.Pizza)
            //    .HasForeignKey(pizzaPrice => pizzaPrice.PizzaId);

            //modelBuilder.Entity<Pizza>()
            //    .Property(p => p.Id)
            //    .HasColumnType("decimal(3,2)");

            modelBuilder.Entity<PizzaPrice>()
                .HasKey(x => new
                {
                    x.PizzaId,
                    x.Size
                });

            //modelBuilder.Entity<PizzaPrice>()
            //    .HasKey("PizzaId", "Size");


            base.OnModelCreating(modelBuilder);
        }
    }
}
