﻿using System.Collections.Generic;
using ToDo.WebApp.Models.Enums;

namespace ToDo.WebApp.Models
{
    public class Task : BaseTask
    {
        public Priority Priority { get; set; }

        public TaskType Type { get; set; }

        public IEnumerable<SubTask> SubTasks { get; set; }
    }
}
