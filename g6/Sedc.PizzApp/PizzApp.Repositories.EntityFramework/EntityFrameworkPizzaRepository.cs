using Microsoft.EntityFrameworkCore;
using PizzApp.Models;
using PizzApp.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzApp.Repositories.EntityFramework
{
    public class EntityFrameworkPizzaRepository : IPizzaRepository
    {
        private readonly ApplicationDatabase Database;

        public EntityFrameworkPizzaRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDatabase>();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PizzaDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            Database = new ApplicationDatabase(optionsBuilder.Options);
        }

        public Pizza Create(Pizza model)
        {
            model.Id = default;
            Database.Pizzas.Add(model);
            int rowsAffected = Database.SaveChanges();
            return model;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAllPizzas()
        {
            return Database.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            return Database.Pizzas
                .FirstOrDefault(pizza => pizza.Id == id);
        }

        public Pizza Update(Pizza pizza)
        {
            var dbPizza = Database.Pizzas.FirstOrDefault(x => x.Id == pizza.Id);
            dbPizza.Name = pizza.Name;
            dbPizza.Description = pizza.Description;
            Database.SaveChanges();
            return dbPizza;
        }
    }
}
