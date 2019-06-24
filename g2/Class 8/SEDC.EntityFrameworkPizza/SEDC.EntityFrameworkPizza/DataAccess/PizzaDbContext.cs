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
        public PizzaDbContext(DbContextOptions options) : base(options)
        {

        }

        // Tables 
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cofigure relations among entities
            modelBuilder.Entity<Order>()
                .HasMany(x => x.Pizzas)
                .WithOne(x => x.Order);

            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    Address = "Partizanski Ordredi br. 24",
                    Name = "Martin Panovski",
                    Phone = "243243242"
                },
                new Order
                {
                    Id = 2,
                    Address = "Pariska 9A",
                    Name = "Dejan Jovanov",
                    Phone = "243243242"
                }
            );
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    Id = 1,
                    Name = "Capri",
                    Size = PizzaSize.Small,
                    OrderId = 1
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Pepperoni",
                    Size = PizzaSize.Medium,
                    OrderId = 1
                }, new Pizza
                {
                    Id = 3,
                    Name = "Napolitana",
                    Size = PizzaSize.Small,
                    OrderId = 2
                }, new Pizza
                {
                    Id = 4,
                    Name = "Margarita",
                    Size = PizzaSize.Large,
                    OrderId = 2
                }
                );
        }
    }
}
