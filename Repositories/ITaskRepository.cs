using Trendx_toDo.Models;
using Trendx_toDo.ViewModels;

namespace Trendx_toDo.Repositories
{
    public interface ITaskRepository
    {
        Task<Todo> AddTaskAsync(CreateTaskViewModel model);
        Task<List<Todo>> GetTasksAsync();
        Task<bool> UpdateTaskAsync(int id, EditTaskViewModel model);
        Task<bool> DeleteTaskAsync(int id);
    }
}
