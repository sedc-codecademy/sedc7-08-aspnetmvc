using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Sedc.OnionArchitecture.Entities;
using Sedc.OnionArchitecture.Repositories.Interfaces;
using Sedc.OnionArchitecture.Services.Interfaces;

namespace Sedc.OnionArchitecture.Services
{
    public class StudentServiceWithGenericRepository : IStudentService
    {
        private readonly IGenericRepository _genericRepository;

        public StudentServiceWithGenericRepository(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public ICollection<Student> GetAll(Expression<Func<Student, bool>> filter = null)
        {
            return _genericRepository.GetAll(filter);
        }

        public Student FindById(int id)
        {
            return _genericRepository.FindById<Student>(id);
        }

        public void Create(Student student)
        {
            _genericRepository.Create(student);
        }

        public void Update(Student student)
        {
            _genericRepository.Update(student);
        }

        public void DeleteById(int id)
        {
            _genericRepository.DeleteById<Student>(id);
        }
    }
}
