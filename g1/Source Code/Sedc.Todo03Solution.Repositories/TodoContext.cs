using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sedc.Todo03Solution.Entities;

namespace Sedc.Todo03Solution.Repositories
{
    public class TodoContext : IdentityDbContext<TodoUser>
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}
