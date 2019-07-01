using Sedc.EntityFramework.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.EntityFramework.WebApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

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
                new Student
                {
                    FirstMidName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01")
                },
                new Student
                {
                    FirstMidName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01")
                },
                new Student {FirstMidName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01")},
                new Student
                {
                    FirstMidName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01")
                },
                new Student
                {
                    FirstMidName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01")
                },
                new Student
                {
                    FirstMidName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01")
                }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }

            var courses = new Course[]
            {
                new Course {Title = "Chemistry", Credits = 3},
                new Course {Title = "Microeconomics", Credits = 3},
                new Course {Title = "Macroeconomics", Credits = 3},
                new Course {Title = "Calculus", Credits = 4},
                new Course {Title = "Trigonometry", Credits = 4},
                new Course {Title = "Composition", Credits = 3},
                new Course {Title = "Literature", Credits = 4}
            };

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
                new Enrollment {Student = students.ElementAt(1), Course = courses.ElementAt(5), Grade = Grade.F},
                new Enrollment {Student = students.ElementAt(2), Course = courses.ElementAt(0)},
                new Enrollment {Student = students.ElementAt(3), Course = courses.ElementAt(0)},
                new Enrollment {Student = students.ElementAt(3), Course = courses.ElementAt(1), Grade = Grade.F},
                new Enrollment {Student = students.ElementAt(4), Course = courses.ElementAt(2), Grade = Grade.C},
                new Enrollment {Student = students.ElementAt(5), Course = courses.ElementAt(3)},
                new Enrollment {Student = students.ElementAt(6), Course = courses.ElementAt(4), Grade = Grade.A},
            };

            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }

            context.SaveChanges();
        }
    }
}
