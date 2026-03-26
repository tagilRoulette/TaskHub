using Api.Controllers.Tasks.Response;
using Api.UseCases.Tasks.Interfaces;
using Logic.Tasks.Services.Interfaces;

namespace Api.UseCases.Tasks
{
    public class ManageTaskUseCase : IManageTaskUseCase
    {
        private readonly ITaskService _taskService;

        public ManageTaskUseCase(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task SetTaskTitleUseCase(Guid id, string title, CancellationToken cancellationToken) =>
            await _taskService.SetTaskTitleAsync(id, title, cancellationToken);

        public async Task<TaskResponse> CreateTaskUseCase(string title, Guid userCreatorId, CancellationToken cancellationToken)
        {
            var task = await _taskService.CreateTaskAsync(title, userCreatorId, cancellationToken);
            return new(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
        }

        public async Task DeleteTasksUseCase(CancellationToken cancellationToken) =>
            await _taskService.DeleteAllTasksAsync(cancellationToken);

        public async Task<bool> DeleteTaskUseCase(Guid id, CancellationToken cancellationToken) =>
            await _taskService.DeleteTaskByIdAsync(id, cancellationToken);

        public async Task<TaskResponseList> GetTasksUseCase(CancellationToken cancellationToken)
        {
            var tasks = await _taskService.GetAllTasksAsync(cancellationToken);
            return new TaskResponseList(
                tasks
                .Select(t => new TaskResponse(t.Id, t.Title, t.CreatedByUserId, t.CreatedUtc))
                .ToArray());
        }

        public async Task<TaskResponse?> GetTaskUseCase(Guid id, CancellationToken cancellationToken)
        {
            var task = await _taskService.GetTaskByIdAsync(id, cancellationToken);
            if (task is null) return null;
            return new(task.Id, task.Title, task.CreatedByUserId, task.CreatedUtc);
        }
    }
}
