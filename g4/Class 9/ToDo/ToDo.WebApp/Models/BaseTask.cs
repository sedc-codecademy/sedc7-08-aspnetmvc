using ToDo.WebApp.Models.Enums;

namespace ToDo.WebApp.Models
{
    public abstract class BaseTask
    {        
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }
    }
}
