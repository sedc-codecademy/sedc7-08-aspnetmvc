using AdoNetDemo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ado.net
{
    class Program
    {
        private const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestPizzaDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static SqlConnection connection = new SqlConnection(connStr);

        static void Main(string[] args)
        {
            connection.Open();
            //execute scalar
            //var numberOfPizzas = GetNumberOfPizzas();
            //Console.WriteLine(numberOfPizzas);

            //execute non query and sql injection
            //Console.Write("id: ");
            //int id = int.Parse(Console.ReadLine());
            //Console.WriteLine();
            //Console.Write("description: ");
            //string description = Console.ReadLine();
            //var rowsAffected = UpdatePizzaDescription(id, description);
            //Console.WriteLine(rowsAffected);

            //execute reader
            IEnumerable<Pizza> pizzas = GetPizzasFromDatabase();
            foreach (var pizza in pizzas)
            {
                Console.WriteLine($"#{pizza.Id}, {pizza.Name} '{pizza.Description}'");
            }

            connection.Close();
        }

        private static IEnumerable<Pizza> GetPizzasFromDatabase()
        {
            string query = "select * from Pizzas";
            var command = new SqlCommand(query, connection);

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
                yield return pizza;
            }
        }

        static int UpdatePizzaDescription(int id, string description)
        {
            string query = $"update Pizzas set Description = @description where Id = @id";
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("description", description);
            command.Parameters.AddWithValue("id", id);

            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }

        static int GetNumberOfPizzas()
        {
            string query = "select count(*) from Pizzas";
            var command = new SqlCommand(query, connection);
            var numberOfPizzas = (int)command.ExecuteScalar();
            return numberOfPizzas;
        }

    }
}
