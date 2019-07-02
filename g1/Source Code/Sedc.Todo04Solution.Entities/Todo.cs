using System;
using System.ComponentModel.DataAnnotations;

namespace Sedc.Todo03Solution.Entities
{
    public class Todo : BaseEntity
    {
        [Required]
        public override int Id { get; set; }
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

        public string UserId { get; set; }
        public TodoUser User { get; set; }

        public Todo()
        {
            DueDate = DateTime.Now;
        }
    }
}
