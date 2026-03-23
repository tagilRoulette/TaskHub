using Dal.Context;
using Dal.Entities;
using Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dal.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _dbContext;

        public TaskRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskEntity> CreateTaskAsync(string title, DateTimeOffset createdUtc, Guid createdByUserId, CancellationToken cancellationToken)
        {
            var task = new TaskEntity()
            {
                Id = Guid.NewGuid(),
                Title = title,
                CreatedByUserId = createdByUserId,
                CreatedUtc = createdUtc
            };
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return task;
        }

        public async Task DeleteAllTasksAsync(CancellationToken cancellationToken) =>
            await _dbContext.Tasks.ExecuteDeleteAsync(cancellationToken);

        public async Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken)
        {
            var matchingIdTasks = _dbContext.Tasks.Where(task => task.Id == taskId);
            if (!matchingIdTasks.Any()) return false;
            await _dbContext.Tasks.Where(task => task.Id.Equals(taskId)).ExecuteDeleteAsync();
            return true;
        }

        public async Task<IReadOnlyCollection<TaskEntity>> GetAllTasksAsync(CancellationToken cancellationToken) =>
            _dbContext.Tasks
            .AsNoTracking()
            .ToArray()
            .AsReadOnly();

        public async Task<TaskEntity?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken) =>
            await _dbContext.Tasks
            .AsNoTracking()
            .FirstOrDefaultAsync(task => task.Id == taskId, cancellationToken);

        public async Task SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken) =>
            await _dbContext.Tasks
            .Where(task => task.Id == taskId)
            .ExecuteUpdateAsync(
                task => task.SetProperty(t => t.Title, title),
                cancellationToken);
    }
}
