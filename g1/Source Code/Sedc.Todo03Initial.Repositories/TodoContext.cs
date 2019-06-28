using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sedc.Todo03Initial.Entities;

namespace Sedc.Todo03Initial.Repositories
{
    public class TodoContext : IdentityDbContext<TodoUser>
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}
