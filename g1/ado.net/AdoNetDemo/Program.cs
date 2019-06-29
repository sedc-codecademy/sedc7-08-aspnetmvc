using System;
using System.Data.SqlClient;

namespace ado.net
{
    class Program
    {
        static void Main(string[] args)
        {
            //executeScalar() - get a number
            //Console.WriteLine(GetNumberOfPizzas());

            //executeNonQuery() - get number of rows affected
            Console.WriteLine("enter pizza id:");
            var pizzaId = int.Parse(Console.ReadLine());
            Console.WriteLine("enter pizza name:");
            var pizzaName = Console.ReadLine();
            Console.WriteLine("Rows affected: " + UpdatePizza(pizzaId, pizzaName));
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
