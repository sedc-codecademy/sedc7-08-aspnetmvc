using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Sedc.Todo01.WebApp.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            var todos = new List<Models.Todo>
            {
                // yesterday
                new Models.Todo{Title = "Yesterday Todo 1", Description = "Yesterday Todo 1 Description", DueDate = DateTime.Today.AddDays(-1)},
                new Models.Todo{Title = "Yesterday Todo 2", Description = "Yesterday Todo 2 Description", DueDate = DateTime.Today.AddDays(-1).AddHours(6)},
                new Models.Todo{Title = "Yesterday Todo 3", Description = "Yesterday Todo 3 Description", DueDate = DateTime.Today.AddDays(-1).AddHours(12)},

                // today
                new Models.Todo{Title = "Today Todo 1", Description = "Today Todo 1 Description", DueDate = DateTime.Today},
                new Models.Todo{Title = "Today Todo 2", Description = "Today Todo 2 Description", DueDate = DateTime.Today.AddHours(6)},
                new Models.Todo{Title = "Today Todo 3", Description = "Today Todo 3 Description", DueDate = DateTime.Today.AddHours(12)},

                // tomorrow
                new Models.Todo{Title = "Tomorrow Todo 1", Description = "Tomorrow Todo 1 Description", DueDate = DateTime.Today.AddDays(1)},
                new Models.Todo{Title = "Tomorrow Todo 2", Description = "Tomorrow Todo 2 Description", DueDate = DateTime.Today.AddDays(1).AddHours(6)},
                new Models.Todo{Title = "Tomorrow Todo 3", Description = "Tomorrow Todo 3 Description", DueDate = DateTime.Today.AddDays(1).AddHours(12)},
            };

            return View(todos);
        }

        public IActionResult Yesterday()
        {
            var date = DateTime.Today.AddDays(-1);

            var todos = new List<Models.Todo>
            {
                // yesterday
                new Models.Todo{Title = "Yesterday Todo 1", Description = "Yesterday Todo 1 Description", DueDate = date},
                new Models.Todo{Title = "Yesterday Todo 2", Description = "Yesterday Todo 2 Description", DueDate = date.AddHours(6)},
                new Models.Todo{Title = "Yesterday Todo 3", Description = "Yesterday Todo 3 Description", DueDate = date.AddHours(12)},
            };

            return View("~/Views/Todo/Index.cshtml", todos);
        }

        public IActionResult Today()
        {
            var date = DateTime.Today;

            var todos = new List<Models.Todo>
            {
                // today
                new Models.Todo{Title = "Today Todo 1", Description = "Today Todo 1 Description", DueDate = date},
                new Models.Todo{Title = "Today Todo 2", Description = "Today Todo 2 Description", DueDate = date.AddHours(6)},
                new Models.Todo{Title = "Today Todo 3", Description = "Today Todo 3 Description", DueDate = date.AddHours(12)},
            };

            return View("~/Views/Todo/Index.cshtml", todos);
        }

        public IActionResult Tomorrow()
        {
            var date = DateTime.Today.AddDays(1);

            var todos = new List<Models.Todo>
            {
                // tomorrow
                new Models.Todo{Title = "Tomorrow Todo 1", Description = "Tomorrow Todo 1 Description", DueDate = date},
                new Models.Todo{Title = "Tomorrow Todo 2", Description = "Tomorrow Todo 2 Description", DueDate = date.AddHours(6)},
                new Models.Todo{Title = "Tomorrow Todo 3", Description = "Tomorrow Todo 3 Description", DueDate = date.AddHours(12)},
            };

            return View("~/Views/Todo/Index.cshtml", todos);
        }
    }
}