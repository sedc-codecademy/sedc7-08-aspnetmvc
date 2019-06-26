using System;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sedc.OnionArchitecture.Repositories;
using Sedc.OnionArchitecture.Repositories.Interfaces;
using Sedc.OnionArchitecture.Services;
using Sedc.OnionArchitecture.Services.Interfaces;

namespace Sedc.OnionArchitecture.ConsoleApp
{
    class Program
    {
        private static readonly IConfiguration _configuration;
        private static readonly DbContext _dbContext;
        private static readonly IGenericRepository _genericRepository;
        private static readonly IStudentService _studentService;
        private static readonly ICourseService _courseService;
        private static readonly string[] _validInputs;

        static Program()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<SchoolContext>();
            dbContextOptionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));

            _dbContext = new SchoolContext(dbContextOptionsBuilder.Options);

            _genericRepository = new GenericRepository(_dbContext);

            _studentService = new StudentServiceWithGenericRepository(_genericRepository);
            _courseService = new CourseServiceWithGenericRepository(_genericRepository);

            _validInputs = new[] { "1", "2", "exit" };
        }

        static void Main(string[] args)
        {
            while (true)
            {
                var sbMenu = new StringBuilder();

                sbMenu.AppendLine("Choose operation:");
                sbMenu.AppendLine("1) List all students");
                sbMenu.AppendLine("2) List all courses");

                Console.Write(sbMenu.ToString());

                var userInput = Console.ReadLine();

                while (!_validInputs.Contains(userInput))
                {
                    Console.WriteLine($"Invalid option: {userInput}");
                    userInput = Console.ReadLine();
                }

                Console.WriteLine();

                switch (userInput)
                {
                    case "1":
                        var students = _studentService.GetAll();
                        var studentsOutput = string.Join(Environment.NewLine,
                            students.Select((student, index) => $"{index + 1}. {student.FirstMidName} {student.LastName}"));
                        Console.WriteLine(studentsOutput);
                        break;
                    case "2":
                        var courses = _courseService.GetAll();
                        var coursesOutput = string.Join(Environment.NewLine,
                            courses.Select((course, index) => $"{index + 1}. Title: {course.Title} Credits: {course.Credits}"));
                        Console.WriteLine(coursesOutput);
                        break;
                    case "exit":
                    default:
                        return;
                }

                Console.WriteLine();
            }
        }
    }
}
