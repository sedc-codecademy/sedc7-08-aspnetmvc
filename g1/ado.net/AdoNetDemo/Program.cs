using System;
using System.Data.SqlClient;

namespace ado.net
{
    class Program
    {
        static void Main(string[] args)
        {
            //executeScalar() - get a number
            Console.WriteLine(GetNumberOfPizzas());
            
            //executeNonQuery() - get number of rows affected
            Console.WriteLine(UpdatePizza(1, "amerikana"));
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
