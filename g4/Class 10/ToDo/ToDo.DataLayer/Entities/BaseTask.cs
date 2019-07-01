using ToDo.DataLayer.Enums;

namespace ToDo.DataLayer.Entities
{
    public abstract class BaseTask
    {        
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }
    }
}
