using Microsoft.AspNetCore.Mvc;
using Sedc.Todo02Solution.WebApp.Data;
using Sedc.Todo02Solution.WebApp.Models;
using System;

namespace Sedc.Todo02Solution.WebApp.Controllers
{
    [Route("")]
    [Route("todo")]
    public class TodoController : Controller
    {
        private readonly Storage _storage;

        public TodoController(Storage storage)
        {
            _storage = storage;
        }

        [Route("")]
        [HttpGet("list")]
        public IActionResult Index()
        {
            var todos = _storage.GetAll();
            return View(todos);
        }

        [HttpGet("add")]
        public IActionResult AddTodo()
        {
            var todo = new Todo();
            return View(todo);
        }

        [HttpPost("add")]
        public IActionResult AddTodo(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }

            _storage.Save(todo);
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public IActionResult EditTodo(Guid id)
        {
            var todo = _storage.FindById(id);
            return View(todo);
        }

        [HttpPost("edit/{id}")]
        public IActionResult EditTodo(Guid id, Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return View(todo);
            }

            _storage.Save(todo);
            return RedirectToAction("Index");
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteTodo(Guid id)
        {
            _storage.DeleteById(id);
            return RedirectToAction("Index");
        }
    }
}