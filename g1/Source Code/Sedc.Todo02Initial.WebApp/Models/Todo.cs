using System;

namespace Sedc.Todo02Initial.WebApp.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Todo()
        {
            Id = Guid.NewGuid();
            DueDate = DateTime.Now;
        }
    }
}
