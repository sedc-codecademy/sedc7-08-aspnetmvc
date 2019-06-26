using System;
using System.Collections.Generic;
using Moq;
using Sedc.OnionArchitecture.Entities;
using Sedc.OnionArchitecture.Repositories.Interfaces;
using Sedc.OnionArchitecture.Services;
using Xunit;

namespace Sedc.OnionArchitecture.UnitTests
{
    public class StudentServiceTests
    {
        [Fact]
        public void ShouldReturnAllStudents()
        {
            var mockRepo = new Mock<IGenericRepository>();
            mockRepo.Setup(repo => repo.GetAll<Student>(null)).Returns(GenerateMockStudents());

            var studentsService = new StudentServiceWithGenericRepository(mockRepo.Object);

            var result = studentsService.GetAll();

            Assert.NotEmpty(result);
            Assert.Equal(8, result.Count);
        }

        private ICollection<Student> GenerateMockStudents()
        {
            return new List<Student>
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
        }
    }
}
