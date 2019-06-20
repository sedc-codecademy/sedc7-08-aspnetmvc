using System;
using System.ComponentModel.DataAnnotations;

namespace Sedc.Todo02Solution.WebApp.Models
{
    public class Todo
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Title { get; set; }
        [Required]
        [MinLength(10)]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public bool IsCompleted { get; set; }

        public Todo()
        {
            Id = Guid.NewGuid();
            DueDate = DateTime.Now;
        }
    }
}
