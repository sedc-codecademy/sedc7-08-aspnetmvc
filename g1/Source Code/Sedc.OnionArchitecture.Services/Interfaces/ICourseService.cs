using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sedc.OnionArchitecture.Entities;

namespace Sedc.OnionArchitecture.Services.Interfaces
{
    public interface ICourseService
    {
        ICollection<Course> GetAll(Expression<Func<Course, bool>> filter = null);
        Course FindById(int id);
        void Create(Course student);
        void Update(Course student);
        void DeleteById(int id);
    }
}