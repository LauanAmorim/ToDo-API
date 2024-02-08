using Microsoft.EntityFrameworkCore;
using Trendx_toDo.Data;
using Trendx_toDo.Models;
using Trendx_toDo.ViewModels;

namespace Trendx_toDo.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> AddTaskAsync(CreateTaskViewModel model)
        {
            var task = new Todo
            {
                Title = model.Title,
                Description = model.Description,
                Completed = model.Completed
            };

            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<List<Todo>> GetTasksAsync()
        {
            return await _context.Tasks.AsNoTracking().ToListAsync();
        }

        public async Task<bool> UpdateTaskAsync(int id, EditTaskViewModel model)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                return false;

            task.Title = model.Title;
            task.Description = model.Description;
            task.Completed = model.Completed;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
