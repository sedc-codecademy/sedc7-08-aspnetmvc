using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Sedc.OnionArchitecture.Entities;
using Sedc.OnionArchitecture.Repositories.Interfaces;
using Sedc.OnionArchitecture.Services.Interfaces;

namespace Sedc.OnionArchitecture.Services
{
    public class StudentServiceWithRepository : IStudentService
    {
        private readonly IRepository<Student> _repository;

        public StudentServiceWithRepository(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public ICollection<Student> GetAll(Expression<Func<Student, bool>> filter = null)
        {
            return _repository.GetAll(filter);
        }

        public Student FindById(int id)
        {
            return _repository.FindById(id);
        }

        public void Create(Student student)
        {
            _repository.Create(student);
        }

        public void Update(Student student)
        {
            _repository.Update(student);
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }
    }
}
