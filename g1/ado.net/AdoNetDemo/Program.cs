using System;
using System.Data.SqlClient;

namespace ado.net
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PizzaDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            //
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select * from Pizzas";
            
            //get number of pizzas
            object scalarResult = sqlCommand.ExecuteScalar();


            //write queries, update pizza name
            int rowsAffected = sqlCommand.ExecuteNonQuery();


            //
            sqlConnection.Close();



        }
    }
}
