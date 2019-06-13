using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sedc.Todo.WebApp.Models
{
    public class Todo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public Todo()
        {
            DueDate = DateTime.Now;
        }
    }
}
