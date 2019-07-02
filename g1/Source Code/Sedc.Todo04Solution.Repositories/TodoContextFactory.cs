using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sedc.Todo03Solution.Repositories
{
    class TodoContextFactory: IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TodoContext>();
            optionsBuilder.UseInMemoryDatabase("TodoApp");

            return new TodoContext(optionsBuilder.Options);
        }
    }
}
