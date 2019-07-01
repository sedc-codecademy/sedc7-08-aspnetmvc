using ToDo.WebApp.Models.Enums;

namespace ToDo.WebApp.Models
{
    public abstract class BaseTask
    {
        public static int LastGeneratedId { get; private set; }

        static BaseTask()
        {
            LastGeneratedId = 0;
        }

        public BaseTask()
        {
            Id = ++LastGeneratedId;
        }
        public int Id { get; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }
    }
}
