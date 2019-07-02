using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AdoNetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //executeScalar() - get a number
            //Console.WriteLine(GetNumberOfPizzas());

            //executeNonQuery() - get number of rows affected
            //Console.WriteLine("enter pizza id:");
            //var pizzaId = int.Parse(Console.ReadLine());
            //Console.WriteLine("enter pizza name:");
            //var pizzaName = Console.ReadLine();
            //Console.WriteLine("Rows affected: S + UpdatePizza(pizzaId, pizzaName));

            //executeReader() - get data from database
            List<Pizza> pizzas = GetPizzasFromDatabase();
            foreach (var pizza in pizzas)
            {
                Console.WriteLine($"#{pizza.Id}, {pizza.Name}, '{pizza.Description}'");
            }
        }

        public static List<Pizza> GetPizzasFromDatabase()
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PizzaDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            var query = $"select * from Pizzas";
            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Connection = sqlConnection;

            var pizzas = new List<Pizza>();
            var sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                int id = (int)sqlReader["Id"];
                string name = (string)sqlReader["Name"];
                string description = sqlReader["Description"] as string ?? string.Empty;
                pizzas.Add(new Pizza
                {
                    Id = id,
                    Name = name,
                    Description = description
                });
            }



            sqlConnection.Close();
            return pizzas;
        }

        public static int UpdatePizza(int pizzaId, string pizzaName)
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PizzaDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            var query = $"UPDATE Pizzas SET Name=@pizzaName where Id = @pizzaId";

            SqlCommand sqlCommand = new SqlCommand(query);
            sqlCommand.Parameters.AddWithValue("pizzaName", pizzaName);
            sqlCommand.Parameters.AddWithValue("pizzaId", pizzaId);
            sqlCommand.Connection = sqlConnection;
            var numberOfPizzas = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return (int)numberOfPizzas;
        }


        public static int GetNumberOfPizzas()
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PizzaDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select count(*) from Pizzas");
            sqlCommand.Connection = sqlConnection;
            var numberOfPizzas = sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            return (int)numberOfPizzas;
        }


    }
}
