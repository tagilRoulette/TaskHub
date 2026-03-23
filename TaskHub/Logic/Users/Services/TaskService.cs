using Dal.Repositories.Interfaces;
using Logic.Users.Models;
using Logic.Users.Services.Interfaces;

namespace Logic.Users.Services
{
    internal sealed class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskModel> CreateTaskAsync(string title, Guid createdByUserId, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.CreateTaskAsync(title, DateTime.UtcNow, createdByUserId, cancellationToken);
            return new(task.Id, task.Title, task.CreatedUtc, task.CreatedByUserId);
        }

        public async Task DeleteAllTasksAsync(CancellationToken cancellationToken)
        {
            await _taskRepository.DeleteAllTasksAsync(cancellationToken);
        }

        public async Task<bool> DeleteTaskByIdAsync(Guid taskId, CancellationToken cancellationToken)
        {
            return await _taskRepository.DeleteTaskByIdAsync(taskId, cancellationToken);
        }

        public async Task<IReadOnlyCollection<TaskModel>> GetAllTasksAsync(CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllTasksAsync(cancellationToken);
            var result = tasks
                .Select(t => new TaskModel(t.Id, t.Title, t.CreatedUtc, t.CreatedByUserId))
                .ToArray();
            return result;
        }

        public async Task<TaskModel?> GetTaskByIdAsync(Guid taskId, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetTaskByIdAsync(taskId, cancellationToken);

            if (task == null)
            {
                return null;
            }

            return new TaskModel(task.Id, task.Title, task.CreatedUtc, task.CreatedByUserId);

        }

        public async Task SetTaskTitleAsync(Guid taskId, string title, CancellationToken cancellationToken)
        {
            await _taskRepository.SetTaskTitleAsync(taskId, title, cancellationToken);
        }
    }
}
