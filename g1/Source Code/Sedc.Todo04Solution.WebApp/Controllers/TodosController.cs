using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sedc.Todo03Solution.Entities;
using Sedc.Todo03Solution.Repositories;
using Sedc.Todo03Solution.Repositories.Interfaces;

namespace Sedc.Todo03Solution.WebApp.Controllers
{
    [Authorize]
    public class TodosController : Controller
    {
        private readonly UserManager<TodoUser> _userManager;
        private readonly IGenericRepository<Todo> _repository;

        public TodosController(UserManager<TodoUser> userManager, IGenericRepository<Todo> repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        // GET: Todos
        public IActionResult Index()
        {
            var todos = _repository.GetAll(todo => todo.User.UserName == User.Identity.Name,
                queryable => queryable.Include(todo => todo.User));
            return View(todos);
        }

        // GET: Todos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = _repository.FindById(id.Value);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // GET: Todos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,DueDate,IsCompleted")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                todo.UserId = user.Id;

                _repository.Create(todo);
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Todos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = _repository.FindById(id.Value);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Description,DueDate,IsCompleted")] Todo todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(todo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoExists(todo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Todos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = _repository.FindById(id.Value);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TodoExists(int id)
        {
            return _repository.GetAll().Any(todo => todo.Id == id);
        }
    }
}
