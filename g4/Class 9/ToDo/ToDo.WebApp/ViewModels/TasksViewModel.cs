using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ToDo.WebApp.Models;

namespace ToDo.WebApp.ViewModels
{
    public class TasksViewModel
    {
        public IEnumerable<Task> Tasks { get; set; }

        public IEnumerable<SelectListItem> Statuses { get; set; }
    }
}
