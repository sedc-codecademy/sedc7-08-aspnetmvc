using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDo.DataLayer.Contracts
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Entities.Task>> GetAllAsync();

        Task<Entities.Task> GetByIdAsync(int id);

        Task AddAsync(Entities.Task task);

        Task<bool> UpdateAsync(Entities.Task task);

        Task RemoveAsync(Entities.Task task);
     }
}
