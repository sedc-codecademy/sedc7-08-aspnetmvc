using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDo.DataLayer.Contracts;
using ToDo.DataLayer.Entities;
using ToDo.DataLayer.Enums;
using ToDo.WebApp.Controllers;
using ToDo.WebApp.Helpers;

namespace Tests
{
    public class TasksDbTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async System.Threading.Tasks.Task TasksDbControllerIndexMethod_ReturnsViewResultAsListOfTasks()
        {
            //// Arrange
            var mockRepo = new Mock<ITaskRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(GetTestTasks());
            var controller = new TasksDbController(mockRepo.Object);

            //// Act
            var result = await controller.Index();

            //// Assert
            Assert.IsInstanceOf<ViewResult>(result);

            var viewResult = (ViewResult)result;

            Assert.IsInstanceOf<IEnumerable<Task>>(
                viewResult.ViewData.Model);

            var model = (IEnumerable<Task>)viewResult.ViewData.Model;
            var expectedTasksCount = 3;
            Assert.AreEqual(expectedTasksCount, model.Count());
        }

        private IEnumerable<Task> GetTestTasks()
        {
            var tasks = new List<Task>
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

            foreach (var task in tasks)
            {
                foreach (var subTask in task.SubTasks)
                {
                    subTask.ParentTask = task;
                }
            }

            return tasks;
        }
    }
}