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
            throw new Exception();
        }

        public Pizza GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Pizza Update(Pizza model)
        {
            throw new NotImplementedException();
        }
    }
}
