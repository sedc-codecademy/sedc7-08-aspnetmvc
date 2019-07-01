using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Sedc.OnionArchitecture.Entities;
using Sedc.OnionArchitecture.Repositories.Interfaces;
using Sedc.OnionArchitecture.Services.Interfaces;

namespace Sedc.OnionArchitecture.Services
{
    public class CourseServiceWithGenericRepository : ICourseService
    {
        private readonly IGenericRepository _genericRepository;

        public CourseServiceWithGenericRepository(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public ICollection<Course> GetAll(Expression<Func<Course, bool>> filter = null)
        {
            return _genericRepository.GetAll(filter);
        }

        public Course FindById(int id)
        {
            return _genericRepository.FindById<Course>(id);
        }

        public void Create(Course student)
        {
            _genericRepository.Create(student);
        }

        public void Update(Course student)
        {
            _genericRepository.Update(student);
        }

        public void DeleteById(int id)
        {
            _genericRepository.DeleteById<Course>(id);
        }
    }
}
