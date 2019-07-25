# ADO.NET 🍞
ADO.NET or active data object .Net is a collection of components, an integratedibrary in the .net framework that contains methods and features for communicating with data structures such as data bases. These features alow developers to manipulate a data base in any shape and form. This means that with it we can do almost anything within our code to a database such as:
* Open connection
* Execute queries
* Execute stored procedures
* Execute transactions
* Close connection

Usually ORMs use this system and do these things easier and in fewer steps. That is why they are preferred over ADO.NET. But since ORMs are automatic most of the times their performance is much much slower. If we need better performance or more control over our database ADO.NET might be a good solution. 
## Sql Database Projet 🔸
SQL Server, when installed gives us a special project template in Visual Studio that we can work with. That us the SQL Database Project. This project is very useful when working with databases because it can hold a representation to our database in code and keep track of changes. Within this project we can sync the database and the representation in code very easily. This project can be used if we need to track changes to a database by a team or commit changes to the database with the project, so that adding sql scripts manually is avoided. It also helps in tracking the database changes when creating projects with the database first aproach. 
### Syncing 🔽
In the SQL Database Project we can add queries for our tables, stored procedures, views and functions. These queries can then be compared to a database to check what the differences are. This is called syncing. Syncing can be done in two ways:
* Syncing the database to our project - Finds changes that are in the project and not in the database. It gives an option to update the database with the changes in the project
* Syncing the project to our database - Finds changes that are in the database and not in the project. It gives an option to update the project with the changes in the database
## Using ADO.NET 🔸
To use ADO.NET we need the **System.Data.SqlClient** library. Some of the project templates already contain a refference to this library. If not, it can simply be added through the NuGet package manager. To use ADO.NET we must follow some rules:
0. Set the connection string to the database
1. Create a method for some functionality
2. Open an SQL Connection and provide with the provided connection string
3. Create an SQL Command ( Class that represents an instruction to SQL )
4. Create an SQL Data Reader if there is a need to read more data
5. Execute the command
6. Get and convert the data needed
7. Close the SQL Connection

### Connection 🔽
When we need something from the database, we don't just take data. We first have to open a connection in order to access the database. This connection requires the address to the database, a connection string. After we open a connection we can send requests and work with the database as we see fit. After we are done we have to close the connection. If we don't close our connections we will have ghost connections to our database. Opened, not used and never closed. These connections can break our communication with the database if we take up all available connections. At that point would not be able to open any more new connections. That is why with ADO.NET we always open and close our connection when we are done with our code.
#### Example
```csharp asp
class Program
{
    private static string _connectionString = "Server=.;Database=BooksDb2019;Trusted_Connection=True;";
    static void Main(string[] args)
    {
        DoThingsInDb();
        Console.ReadLine();
    }
    private static void DoThingsInDb()
    {
	    // Creating a connection object with the connection string
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open(); // Opening the connection
		// Requests to the database
        connection.Close(); // Closing the connection
    }
}
```
### Sending an SQL querry 🔽
In order to communicate with the database we first need to create an SQL Command. This class is a representation of an instruction that we can send to the SQL database. The command accepts a query ( string ) and if it is required parameters ( for stored procedures, functions etc. ). After we add the query and parameters we need to execute the command to the database. This can be done in few different ways:
* Executing and getting the first column of the table as a result
* Executing and getting the whole data from the result
* Executing the command but only getting rows affected as reslt
* Executes the command and gets the result in an XML friendly form
#### Example
```csharp asp
private static void CountRecords()
{
    SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();

	// We create a command object and set it up
    SqlCommand cmd = new SqlCommand(); // Instance
    cmd.Connection = connection; // Add connection
    cmd.CommandText = "select count(*) from Authors"; // Add query
	
	// Executing the command, getting the first row and column of the result and converting it to type int
    int authorCount = (int)cmd.ExecuteScalar();

    Console.WriteLine($"Authors count: {authorCount}");

    connection.Close();
}
```
### Receiving Data 🔽
When getting data from the SQL Command, we can either get direct data ( Scalar, NonQuery ) or we can get data that needs to be converted and mapped in order to be used ( Reader and XMLReader ). When we get data that needs mapping and converting, for instance from ExecuteReader, we need to first create an instance of the class SqlDataReader. This class contains the data from the database and has functionalities and features that help us extract the correct information from our result. This is usually used when we need to get a whole table and need to target different columns and cells from the table. 
> Important: We need to know the precise names of the columns since Visual Studio wont help us with suggestions
#### Example
```csharp asp
private static void RetrieveAuthors(byte approach)
{
    SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();

    SqlCommand cmd = new SqlCommand();
    cmd.Connection = connection;
    cmd.CommandText = "select ID, Name, DateOfBirth from Authors";
	// Executing the command, getting the whole table and storing it in an SqlDataReader object
    SqlDataReader dr = cmd.ExecuteReader();
	
	// Variables for the data we need ( Could be an object )
    int authorId = 0;
    string name = null;
    DateTime? dob = null;

	// Going through all records in the result table stored in the Data Reader
    while (dr.Read())
    {
	    // Three aproaches on how to get data from a table
        switch (approach)
        {
	        // Getting data from the number of the column
            case 1:
                authorId = dr.GetInt32(0);
                name = dr.GetString(1);
                break;
            // Getting data from the number of the column ( generic )
            case 2:
	            authorId = dr.GetFieldValue<int>(0);
                name = dr.GetFieldValue<string>(1);
                break;
            // Getting data from the names of the columns
            case 3:
                authorId = (int)dr["ID"];
                name = (string)dr["Name"];
                break;
        }
		// Checking if a column is null ( to not get error while casting it in to DateTime )
        dob = dr.IsDBNull(2) ? (DateTime?)null : (DateTime)dr["DateOfBirth"];

        Console.WriteLine($"ID: {authorId} - Name:{name} - DateOfBirth:{dob}");
    }

    connection.Close();
}
```
### Sending parameters to SQL 🔽
When sending parameters to SQL we need to be aware of the dangers that we can expose our database to. There are many ways that we can unintentionally  expose our database to our users. The process of a user sending something in an input to harm or infiltrate our SQL database is called **SQL INJECTION**. A good way to avoid this is making sure that the parameters that we accept are always sent as SQL parameters instead of incorporating them in the query string it self. 
#### Bad Example
```csharp asp
private static void FilterAuthorsUnsafe(byte approach)
{
    SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();

    Console.Write("Enter author name: ");
    string query = Console.ReadLine();

    SqlCommand cmd = new SqlCommand();
    cmd.Connection = connection;
    // Do not send the string that from the user input in to the query directly
    cmd.CommandText = "select ID, Name, DateOfBirth from Authors where Name like '%" + query + "%'";

    SqlDataReader dr = cmd.ExecuteReader();

    int authorId = 0;
    string name = null;

    while (dr.Read())
    {
        switch (approach)
        {
            case 1:
                authorId = dr.GetInt32(0);
                name = dr.GetString(1);
                break;
            case 2:
                authorId = dr.GetFieldValue<int>(0);
                name = dr.GetFieldValue<string>(1);
                break;
        }

        DateTime? dob = dr.IsDBNull(2)
            ? (DateTime?)null
            : (DateTime)dr["DateOfBirth"];

        Console.WriteLine($"AuthorId:{authorId} - Name:{name} - DateOfBirth:{dob}");
    }

    connection.Close();
}
```
#### Good Example
```csharp asp
private static void FilterAuthorsWithParameters()
{
    SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();

    Console.Write("Enter author name: ");
    string query = Console.ReadLine();

    SqlCommand cmd = new SqlCommand();
    cmd.Connection = connection;
    // We concatinate the SQL variable in to the query
    cmd.CommandText = "select ID, Name, DateOfBirth from Authors where Name like '%'+@authorName+'%'";
    // We set the paramter for the user input
    cmd.Parameters.AddWithValue("@authorName", query);

    SqlDataReader dr = cmd.ExecuteReader();

    while (dr.Read())
    {
        int authorId = (int)dr["ID"];
        string name = (string)dr["Name"];
        DateTime? dob = dr.IsDBNull(2)
            ? (DateTime?)null
            : (DateTime)dr["DateOfBirth"];

        Console.WriteLine($"AuthorId:{authorId} - Name:{name} - DateOfBirth:{dob}");
    }
    connection.Close();
}
```
### Executing stored procedure 🔽
When a complex or often used query is needed, it might be a good idea to create a stored procedure for it. Stored procedures are created in the database or from an SQL Database project. After that we can execute them using the ADO.NET Framework. The only thing that we need to add is parameters. 
> Important: We need to know the precise name of the parameters since Visual Studio wont help us with suggestions
#### Example
```csharp asp
private static void StoredProcedure()
{
    SqlConnection connection = new SqlConnection(_connectionString);
    connection.Open();

    Console.Write("Enter author name: ");
    string query = Console.ReadLine();

    SqlCommand cmd = new SqlCommand();
    cmd.Connection = connection;
    // We set the type of the command to mark it as a request to a stored procedure
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    // We enter the name of the stored procedure
    cmd.CommandText = "getAuthors";
    // We enter the parameters that the stored procedure needs
    cmd.Parameters.AddWithValue("@authorName", query);

    SqlDataReader dr = cmd.ExecuteReader();

    while (dr.Read())
    {
        int authorId = (int)dr["ID"];
        string name = (string)dr["Name"];
        DateTime? dob = dr.IsDBNull(2)
            ? (DateTime?)null
            : (DateTime)dr["DateOfBirth"];

        Console.WriteLine($"{authorId} - {name} - {dob}");
    }

    connection.Close();
}
}
```

## Extra Materials 📘
* [Benefits of SQL Database Projects](https://koukia.ca/benefits-of-sql-server-database-projects-7f3545b283d6)
* [Introduction to ADO.NET](https://www.c-sharpcorner.com/uploadfile/puranindia/what-is-ado-net/)
* [Microsoft Examples of ADO.NET](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/ado-net-code-examples)
