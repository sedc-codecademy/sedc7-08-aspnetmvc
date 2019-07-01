using System;
using System.Data.SqlClient;

namespace ado.net
{
    class Program
    {
        private const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestPizzaDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static SqlConnection connection = new SqlConnection(connStr);

        static void Main(string[] args)
        {
            connection.Open();
            //var numberOfPizzas = GetNumberOfPizzas();
            //Console.WriteLine(numberOfPizzas);
            Console.Write("id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("description: ");
            string description = Console.ReadLine();
            var rowsAffected = UpdatePizzaDescription(id, description);
            Console.WriteLine(rowsAffected);
            connection.Close();
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
