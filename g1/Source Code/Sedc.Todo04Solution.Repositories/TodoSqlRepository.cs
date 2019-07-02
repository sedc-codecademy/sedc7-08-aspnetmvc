﻿using Microsoft.EntityFrameworkCore.Query;
using Sedc.Todo03Solution.Entities;
using Sedc.Todo03Solution.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sedc.Todo04Solution.Repositories
{
    public class TodoSqlRepository : IGenericRepository<Todo>
    {
        public void Create(Todo model)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Todo FindById(int id, Func<IQueryable<Todo>, IIncludableQueryable<Todo, object>> include = null)
        {
            throw new NotImplementedException();
        }

        public ICollection<Todo> GetAll(Expression<Func<Todo, bool>> filter = null, Func<IQueryable<Todo>, IIncludableQueryable<Todo, object>> include = null)
        {
            throw new NotImplementedException("implement get_all with sql ado.net");
            ICollection<Todo> dbResults = new List<Todo>();
            return dbResults.Where(filter.Compile()).ToList();
        }

        public void Update(Todo model)
        {
            throw new NotImplementedException();
        }
    }
}
