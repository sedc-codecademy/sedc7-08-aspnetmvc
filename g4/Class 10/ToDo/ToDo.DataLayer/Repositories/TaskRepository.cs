using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.DataLayer.Contracts;

namespace ToDo.DataLayer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksDbContext _dbContext;

        public TaskRepository(TasksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Entities.Task task)
        {
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entities.Task>> GetAllAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<Entities.Task> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks
                                    .SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task RemoveAsync(Entities.Task task)
        {
            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Entities.Task task)
        {
            try
            {
                _dbContext.Update(task);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                //todo: log somewhere the exception
                return false;
            }
        }

        private bool TaskExists(int id)
        {
            return _dbContext.Tasks.Any(e => e.Id == id);
        }
    }
}
