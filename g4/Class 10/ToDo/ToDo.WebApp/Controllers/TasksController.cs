using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDo.DataLayer.Entities;
using ToDo.DataLayer.Enums;
using ToDo.WebApp.Helpers;
using ToDo.WebApp.Models;
//using todoModels = ToDo.WebApp.Models;
using ToDo.WebApp.ViewModels;
//using System.Threading.Tasks;

namespace ToDo.WebApp.Controllers
{
    public class TasksController : Controller
    {
        private static IList<Task> _tasks;

        static TasksController()
        {
            InitializeTasks();
        }

        private static void InitializeTasks()
        {
            _tasks = new List<Task>
            {
                new Task
                {
                    Id = IdGenerator.NextId,
                    Description = "Task 1 description",
                    Priority = Priority.Important,
                    Status = Status.ToDo,
                    Title = "Task 1 title",
                    Type = TaskType.Work,
                    SubTasks = new List<SubTask>
                    {
                        new SubTask
                        {
                            Id = IdGenerator.NextId,
                            Description = "SubTask 1, Task 1 description",
                            Status = Status.ToDo,
                            Title = "SubTask 1, Task 1 title"
                        },
                        new SubTask
                        {
                            Id = IdGenerator.NextId,
                            Description = "SubTask 2, Task 1 description",
                            Status = Status.Done,
                            Title = "SubTask 2, Task 1 title"
                        },
                        new SubTask
                        {
                            Id = IdGenerator.NextId,
                            Description = "SubTask 3, Task 1 description",
                            Status = Status.InProgress,
                            Title = "SubTask 3, Task 1 title"
                        }
                    }
                },
                new Task
                {
                    Id = IdGenerator.NextId,
                    Description = "Task 2 description",
                    Priority = Priority.Medium,
                    Status = Status.InProgress,
                    Title = "Task 2 title",
                    Type = TaskType.Hobby,
                    SubTasks = new List<SubTask>
                    {
                        new SubTask
                        {
                            Id = IdGenerator.NextId,
                            Description = "SubTask 1, Task 2 description",
                            Status = Status.InProgress,
                            Title = "SubTask 1, Task 2 title"
                        }
                    }
                },
                new Task
                {
                    Id = IdGenerator.NextId,
                    Description = "Task 3 description",
                    Priority = Priority.NotImportant,
                    Status = Status.Done,
                    Title = "Task 3 title",
                    Type = TaskType.Personal,
                    SubTasks = new List<SubTask>
                    {
                        new SubTask
                        {
                            Id = IdGenerator.NextId,
                            Description = "SubTask 1, Task 3 description",
                            Status = Status.Done,
                            Title = "SubTask 1, Task 3 title"
                        },
                        new SubTask
                        {
                            Id = IdGenerator.NextId,
                            Description = "SubTask 2, Task 3 description",
                            Status = Status.Done,
                            Title = "SubTask 2, Task 3 title"
                        }
                    }
                },

            };

            foreach (var task in _tasks)
            {
                foreach (var subTask in task.SubTasks)
                {
                    subTask.ParentTask = task;
                }
            }
        }

        public IActionResult Index(Status? status)
        {
            IEnumerable<Task> filteredTasks;
            if (status == null)
                filteredTasks = _tasks;
            else
                filteredTasks = _tasks.Where(t => t.Status == status);

            Array enumValues = Enum.GetValues(typeof(Status));
            var statusListItems = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = " - All - ",
                    Value = string.Empty,
                    Selected = !status.HasValue
                }
            };
            foreach (object enumValue in enumValues)
            {
                var selectListItem = new SelectListItem
                {
                    Value = enumValue.ToString(),
                    Text = Enum.GetName(typeof(Status), enumValue),
                    Selected = status.HasValue 
                                        && (int)enumValue == (int)status
                };

                statusListItems.Add(selectListItem);
            }

            var viewModel = new TasksViewModel
            {
                Tasks = filteredTasks,
                Statuses = statusListItems
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(Task task)
        {
            if (ModelState.IsValid)
            {
                _tasks.Add(task);

                return RedirectToAction("ToDo");
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            var task = _tasks.SingleOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound($"Task with id: {id} was not found");

            return View(task);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _tasks.SingleOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound($"Task with id: {id} was not found");

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(Task editedTask)
        {
            var task = _tasks.SingleOrDefault(t => t.Id == editedTask.Id);
            if (task == null)
                return NotFound($"Task was not found");

            task.Priority = editedTask.Priority;
            task.Status = editedTask.Status;
            task.Title = editedTask.Title;
            task.Type = editedTask.Type;
            task.Description = editedTask.Description;

            return RedirectToAction("Index");
        }
    }
}