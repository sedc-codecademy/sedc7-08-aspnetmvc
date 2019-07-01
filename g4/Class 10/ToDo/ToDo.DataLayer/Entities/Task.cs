using System.Collections.Generic;
using ToDo.DataLayer.Enums;

namespace ToDo.DataLayer.Entities
{
    public class Task : BaseTask
    {
        public Priority Priority { get; set; }

        public TaskType Type { get; set; }

        public IEnumerable<SubTask> SubTasks { get; set; }
    }
}
