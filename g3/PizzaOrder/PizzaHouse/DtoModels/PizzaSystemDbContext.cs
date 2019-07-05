using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DtoModels
{
    public class PizzaSystemDbContext : DbContext
    {
        public PizzaSystemDbContext(DbContextOptions<PizzaSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<IngredientAllergen> IngredientAllergens { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientAllergen>()
                .HasKey(x => new { x.IngredientId, x.AllergenId });
            modelBuilder.Entity<IngredientAllergen>()
                .HasOne(bc => bc.Ingredient)
                .WithMany(b => b.IngredientAllergens)
                .HasForeignKey(bc => bc.IngredientId);
            modelBuilder.Entity<IngredientAllergen>()
                .HasOne(bc => bc.Allergen)
                .WithMany(c => c.IngredientAllergens)
                .HasForeignKey(bc => bc.AllergenId);

            modelBuilder.Entity<PizzaIngredient>()
                .HasKey(x => new { x.PizzaId, x.IngredientId });
            modelBuilder.Entity<PizzaIngredient>()
                .HasOne(bc => bc.Pizza)
                .WithMany(b => b.PizzaIngredients)
                .HasForeignKey(bc => bc.PizzaId);
            modelBuilder.Entity<PizzaIngredient>()
                .HasOne(bc => bc.Ingredient)
                .WithMany(c => c.PizzaIngredients)
                .HasForeignKey(bc => bc.IngredientId);

            modelBuilder.Entity<Pizza>()
                .HasMany(c => c.OrderItems)
                .WithOne(e => e.Pizza)
                .HasForeignKey(x => x.PizzaId);

            modelBuilder.Entity<Order>()
                .HasMany(c => c.OrderItems)
                .WithOne(e => e.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Orders)
                .WithOne(e => e.User);

            #region Seed

            var allergens = new List<Allergen>
            {
                new Allergen("milk"){Id = 1},
                new Allergen("seed"){Id = 2}
            };

            var ingredients = new List<Ingredient>
            {
                new Ingredient("Cheese") {Id = 1},
                new Ingredient("Ham"){Id = 2},
                new Ingredient("Tomato sauce"){Id = 3},
                new Ingredient("Mushrooms"){Id = 4}
            };

            var ingredientAllergens = new List<IngredientAllergen>
            {
                new IngredientAllergen {IngredientId = 1, AllergenId = 1},
                new IngredientAllergen {IngredientId = 3, AllergenId = 2}
            };

            var users = new List<User>
            {
                new User("Risto", "Skopje", "+389111111", "risto@gmail.com", "risto") {Id = 1},
                new User("Martin", "Skopje", "+389222222", "martin@gmail.com", "martin"){Id = 2}
            };

            modelBuilder.Entity<Allergen>().HasData(allergens);
            modelBuilder.Entity<Ingredient>().HasData(ingredients);
            modelBuilder.Entity<IngredientAllergen>().HasData(ingredientAllergens);
            modelBuilder.Entity<User>().HasData(users);

            #endregion
        }
    }
}
