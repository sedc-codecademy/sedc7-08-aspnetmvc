using ToDo.WebApp.Models.Enums;

namespace ToDo.WebApp.Models
{
    public class SubTask : BaseTask
    {
        public Task ParentTask { get; set; }
    }
}
