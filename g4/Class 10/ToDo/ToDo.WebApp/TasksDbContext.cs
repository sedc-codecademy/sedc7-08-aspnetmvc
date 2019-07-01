using Microsoft.EntityFrameworkCore;
using ToDo.DataLayer.Entities;

namespace ToDo.WebApp
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
