using PizzApp.Models;
using PizzApp.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PizzApp.Repositories.AdoNet
{
    public class SqlPizzaRepository : IPizzaRepository
    {
        private readonly SqlConnection Connection;

        public SqlPizzaRepository(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void AddPrice(PizzaPrice pizzaPrice)
        {
            throw new NotImplementedException();
        }

        public Pizza Create(Pizza model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAllPizzas()
        {
            var list = new List<Pizza>();
            string query = "select * from Pizzas";
            var command = new SqlCommand(query, Connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var id = (int)reader["Id"];
                string name = (string)reader["Name"];
                string desctiption = reader["Description"] as string ?? "DBNULL";
                var pizza = new Pizza
                {
                    Id = id,
                    Description = desctiption,
                    Name = name
                };
                list.Add(pizza);
            }
            return list;
        }

        public Pizza GetById(int id)
        {
            string query = $"select * from Pizzas where Id = @id";
            var command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("id", id);
            var pizza = new Pizza();
            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                var ID = (int)reader["Id"];
                string name = (string)reader["Name"];
                string desctiption = reader["Description"] as string ?? "DBNULL";
                pizza = new Pizza
                {
                    Id = ID,
                    Description = desctiption,
                    Name = name
                };
            }
            pizza.PizzaPrices = GetPricesForPizza(id);
            return pizza;
        }

        private List<PizzaPrice> GetPricesForPizza(int pizzaId)
        {
            var list = new List<PizzaPrice>();
            string query = "select * from PizzaPrices where PizzaId = @pizzaId";
            var command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("pizzaId", pizzaId);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    double price = (double)reader["Price"];
                    int size = (int)reader["Size"];
                    var pizzaPrice = new PizzaPrice
                    {
                        PizzaId = pizzaId,
                        Price = price,
                        Size = size
                    };
                    list.Add(pizzaPrice);
                }
            }
            return list;
        }

        public Pizza Update(Pizza model)
        {
            throw new NotImplementedException();
        }
    }
}
