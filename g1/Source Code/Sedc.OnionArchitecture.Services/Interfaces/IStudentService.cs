using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Sedc.OnionArchitecture.Entities;

namespace Sedc.OnionArchitecture.Services.Interfaces
{
    public interface IStudentService
    {
        ICollection<Student> GetAll(Expression<Func<Student, bool>> filter = null);
        Student FindById(int id);
        void Create(Student student);
        void Update(Student student);
        void DeleteById(int id);
    }
}