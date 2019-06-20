using Sedc.Todo02Solution.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sedc.Todo02Solution.WebApp.Data
{
    public class Storage
    {
        private static readonly List<Todo> _todoList;

        static Storage()
        {
            _todoList = new List<Todo>();
        }

        public List<Todo> GetAll(Expression<Func<Todo, bool>> filter = null)
        {
            return _todoList.Where(x => filter == null || filter.Compile()(x)).ToList();
        }

        public Todo FindById(Guid id)
        {
            return _todoList.FirstOrDefault(x => x.Id == id);
        }

        public void Save(Todo todo)
        {
            if (_todoList.Any(x => x.Id == todo.Id))
                _todoList[_todoList.FindIndex(x => x.Id == todo.Id)] = todo;
            else
                _todoList.Add(todo);
        }

        public void DeleteById(Guid id)
        {
            if (_todoList.Any(x => x.Id == id))
                _todoList.RemoveAt(_todoList.FindIndex(x => x.Id == id));
        }
    }
}
