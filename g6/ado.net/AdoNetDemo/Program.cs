using System;
using System.Data.SqlClient;

namespace ado.net
{
    class Program
    {
        private const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestPizzaDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(connStr);
            connection.Open();
            //////
            string query = "select count(*) from Pizzas";
            var command = new SqlCommand(query, connection);
            var numberOfPizzas = (int)command.ExecuteScalar();
            Console.WriteLine(numberOfPizzas);
            /////
            connection.Close();
        }
    }
}
