using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDo.WebApp.Models;
//using todoModels = ToDo.WebApp.Models;
using ToDo.WebApp.Models.Enums;
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
                    Description = "Task 1 description",
                    Priority = Priority.Important,
                    Status = Status.ToDo,
                    Title = "Task 1 title",
                    Type = TaskType.Work,
                    SubTasks = new List<SubTask>
                    {
                        new SubTask
                        {
                            Description = "SubTask 1, Task 1 description",
                            Status = Status.ToDo,
                            Title = "SubTask 1, Task 1 title"
                        },
                        new SubTask
                        {
                            Description = "SubTask 2, Task 1 description",
                            Status = Status.Done,
                            Title = "SubTask 2, Task 1 title"
                        },
                        new SubTask
                        {
                            Description = "SubTask 3, Task 1 description",
                            Status = Status.InProgress,
                            Title = "SubTask 3, Task 1 title"
                        }
                    }
                },
                new Task
                {
                    Description = "Task 2 description",
                    Priority = Priority.Medium,
                    Status = Status.InProgress,
                    Title = "Task 2 title",
                    Type = TaskType.Hobby,
                    SubTasks = new List<SubTask>
                    {
                        new SubTask
                        {
                            Description = "SubTask 1, Task 2 description",
                            Status = Status.InProgress,
                            Title = "SubTask 1, Task 2 title"
                        }
                    }
                },
                new Task
                {
                    Description = "Task 3 description",
                    Priority = Priority.NotImportant,
                    Status = Status.Done,
                    Title = "Task 3 title",
                    Type = TaskType.Personal,
                    SubTasks = new List<SubTask>
                    {
                        new SubTask
                        {
                            Description = "SubTask 1, Task 3 description",
                            Status = Status.Done,
                            Title = "SubTask 1, Task 3 title"
                        },
                        new SubTask
                        {
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

        public IActionResult Index(Status status = Status.ToDo)
        {
            var todoTasks = _tasks.Where(t => t.Status == status);

            var statuses = Enum.GetNames(typeof(Status));

            ViewBag.SelectedStatus = status;

            return View(todoTasks);
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
    }
}