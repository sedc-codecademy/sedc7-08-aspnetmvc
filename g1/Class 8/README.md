# Connecting to DataBase 🥞
Web applications change dynamically depending on the data that is requested. This makes accessing, managing and working with data  an integral part to a web application. Data can be kept in different data structures, but a data base is the  most commonly used. An application can work with a database as long as it has the right address and authorization to work with that database. The thing that makes a difference is not the connecting but how we manipulate and use the database from our application. In ASP.NET applications we can do that with:
* ADO.NET - system from the .NET framework that manages connecting and manipulating with a database. Used for manually opening/ closing connections to the database, as well as manipulating records by writing queries
* ORM framework -  A system that does the communication between code and data-base automatic in a way ( easier to communicate )
## What is ORM  🔸
Object relational mapping is the process where we create a relation between two types of data simpler and easier. In the case of web application, we need our classes and logic to be understood and written in a data-base ( MSSQL ) which does not know how to communicate with our code ( C# ). To make things easier we use an object relational mapping framework that can bridge this gap, so that we can easily write C# logic and update the database or the other way around. These frameworks usually has an abstract representation of the data structure so that it can serve both sides of the application. 
## Entity Framework 🔸
One of the most popular object relational mapping frameworks for .NET is Entity Framework. The framework works with ADO.NET in the background, meaning that we still use ADO.NET to make calls to a database, but it builds it's own queries depending on what we request from it and how we change our code. Entity Framework comes with every ASP.NET MVC application already installed.  With entity framework we can approach the problem with connecting to a database by:
* Code First - Creating classes and connecting them so that the framework can create a database
* Data Base First - Creating a database and connecting everything so that from that the framework creates code structure ( classes )
* Model First - Create a model in a designer ( like diagram ) and from that the framework creates database and code structure ( classes )

The Code First is the most .NET friendly way of approaching data base connection and it can be done by simply creating classes and a context. Entity framework looks at the classes and the context and makes a database from that. Every property becomes a column and every class a table. The relations they have become keys and constraints. Keep in mind that the framework will not work if the code and the database get out of sync, so we must keep them sync when making changes directly to the database or in the domain classes.

### Context 🔽
The context is the code representation of our database. It is a special class that keeps track of what should be mapped in to the database. The context is also a point of entry to the database, meaning that we use the context to add, delete, update and read from the database. Ex: If we add in the context a User and that User has 2 Orders, entity framework will take the info that we added in to the context and try and add it to the database, one user column connected and 2 columns in order which are connected with one to many relationship. Relationships and configurations as well as adding data ( seeding ) to our database can be done through the context
```csharp
using Project.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity.Framework.Demo.Database
{
    // Must inherit from DbContext
    public class SchoolContext : DbContext
    {
        // Configuring the context
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options){}
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
    }

    // Just a simple class that will fill our context/database with some initial data (we will call it later in the example)
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            // Basically checks if the database is created, if it's not then it will created it
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            // Simple array of students which we will use to fill our context/database
            var students = new Student[]
            {
                new Student
                {
                    FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01")
                },
                new Student
                {
                    FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01")
                },
            };

            // Adds every student in students array into the context in the Students DbSet
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }

            // Simple array of Courses
            var courses = new Course[]
            {
                new Course {Title = "Chemistry", Credits = 3},
                new Course {Title = "Microeconomics", Credits = 3},
                new Course {Title = "Macroeconomics", Credits = 3},
                new Course {Title = "Calculus", Credits = 4},
                new Course {Title = "Trigonometry", Credits = 4},
            };

            // Does the same as previous foreach statement but for Courses
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }

            var enrollments = new Enrollment[]
            {
                new Enrollment {Student = students.ElementAt(0), Course = courses.ElementAt(0), Grade = Grade.A},
                new Enrollment {Student = students.ElementAt(0), Course = courses.ElementAt(1), Grade = Grade.C},
                new Enrollment {Student = students.ElementAt(0), Course = courses.ElementAt(2), Grade = Grade.B},
                new Enrollment {Student = students.ElementAt(1), Course = courses.ElementAt(3), Grade = Grade.B},
                new Enrollment {Student = students.ElementAt(1), Course = courses.ElementAt(4), Grade = Grade.F},
            };

            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }

            // Writes the changes from the context into the database
            context.SaveChanges();
        }
    }
}
```
```csharp
// Startup.cs

public void ConfigureServices(IServiceCollection services)
{
    services.Configure<CookiePolicyOptions>(options =>
    {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    // SchoolContext register
    services.AddDbContext<SchoolContext>(options =>
        // Sets a connection string for our context (it looks in the appsettings.json for a "DefaultConnection")
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddMvc();
}
```
```json
// appSettings.json
// Registers a connection string (used in Context registering in Startup.cs)
{
    "ConnectionStrings": {
        "DefaultConnection": "Data Source=MKSK-LPT-013;Initial Catalog=ContosoUniversity;Integrated Security=True"
    },
    "someOtherSettings": {
        "someSetting": "..."
    }
}

Note: *Data Source* is actually server name where you database should be located and *Initial Catalog* is the database name, you should change this depending on your needs.
```
```csharp
public static void Main(string[] args)
{
    var host = CreateWebHostBuilder(args).Build();

    // NOTE: Do not focus on this using statement, basicly what this does is: It runs DbInitializer on application start if we don't already have data or database
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            // Gets our only instance of SchoolContext so that we can pass it in the Initialize method to fill it with initial data
            var context = services.GetRequiredService<SchoolContext>();
            // We execute DbInitializer that we defined earler and pass SchoolContext
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            // In case of an exception, we have a logger to log the error, don't focus on it right now, just know that it logs errors and thats all
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
        }
    }

    host.Run();
}
```
### Migrations 🔽
In order for entity framework to keep track with all the changes in our code and the database, it uses migrations. Migrations are basically change requests from the code to the database. Every time we change the domain models or the context we must create a migration, request that the database change accordingly. We do this with the NuGet Package Manager Console which can be found:
1. Tools
2. NuGet Package Manager
3. Package Manager Console
4. A console will open at the bottom of your visual studio instance

### Creating a database and migrations 🔽
In order for us to create a database first we need to create a migration. This is the first migration from which the database will be built. This migration is usually called something like init or with the word init to mark it as the first initial migration. After we do a migration, the migration is created in our project. Migrations in the project do not change the database. If we want to update the database with the latest migration we must write a command.
#### Add Migration Command
```cmd
add-migration Init
```
#### Update Database
```cmd
update-database
```
## Extra Materials 📘
* [Microsoft step-by-step Example](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-2.2)
* [Microsoft documentation on EF Core](https://docs.microsoft.com/en-us/ef/core/)
* [Getting Started with EF Core](https://www.learnentityframeworkcore.com/walkthroughs/aspnetcore-application)
