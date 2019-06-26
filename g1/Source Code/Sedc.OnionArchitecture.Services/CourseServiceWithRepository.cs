using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Sedc.OnionArchitecture.Entities;
using Sedc.OnionArchitecture.Repositories.Interfaces;
using Sedc.OnionArchitecture.Services.Interfaces;

namespace Sedc.OnionArchitecture.Services
{
    public class CourseServiceWithRepository : ICourseService
    {
        private readonly IRepository<Course> _repository;

        public CourseServiceWithRepository(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public ICollection<Course> GetAll(Expression<Func<Course, bool>> filter = null)
        {
            return _repository.GetAll(filter);
        }

        public Course FindById(int id)
        {
            return _repository.FindById(id);
        }

        public void Create(Course student)
        {
            _repository.Create(student);
        }

        public void Update(Course student)
        {
            _repository.Update(student);
        }

        public void DeleteById(int id)
        {
            _repository.DeleteById(id);
        }
    }
}
