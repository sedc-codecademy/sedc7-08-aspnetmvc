using Microsoft.EntityFrameworkCore;
using SEDC.EntityFrameworkPizza.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.EntityFrameworkPizza.DataAccess
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions options) 
            : base(options){}
        // Tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            // Configuring relation between Order and Pizza
            modelBuilder.Entity<Order>()
                .HasMany(x => x.Pizzas)
                .WithOne(x => x.Order);
            // Seeding ( adding data initially when database is created )
            modelBuilder.Entity<Order>()
                .HasData(
                new Order()
                {
                    Id = 1,
                    Name = "Bob Bobsky",
                    Address = "Bobsky Street",
                    Phone = "0800-3435-3444"
                },
                new Order()
                {
                    Id = 2,
                    Name = "Jill Wayne",
                    Address = "Jill Street",
                    Phone = "0800-3422-5455"
                }
                );
            modelBuilder.Entity<Pizza>()
                .HasData(
                new Pizza()
                {
                    Id = 1,
                    Name = "Kapri",
                    Size = PizzaSize.Large,
                    OrderId = 1
                },
                new Pizza()
                {
                    Id = 2,
                    Name = "Peperoni",
                    Size = PizzaSize.Medium,
                    OrderId = 1
                },
                new Pizza()
                {
                    Id = 3,
                    Name = "Kapri",
                    Size = PizzaSize.Family,
                    OrderId = 2
                },
                new Pizza()
                {
                    Id = 4,
                    Name = "Margarita",
                    Size = PizzaSize.Medium,
                    OrderId = 2
                }
                );
        }
    }
}
