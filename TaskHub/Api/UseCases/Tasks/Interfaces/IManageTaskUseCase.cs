using Api.Controllers.Tasks.Response;

namespace Api.UseCases.Tasks.Interfaces;
public interface IManageTaskUseCase
{
    Task<TaskResponse> CreateTaskUseCase(string? title, Guid? createdByUserId, CancellationToken cancellationToken);
    Task<TaskResponseList> GetTasksUseCase(CancellationToken cancellationToken);
    Task<TaskResponse?> GetTaskUseCase(Guid id, CancellationToken cancellationToken);
    Task SetTaskTitleUseCase(Guid id, string title, CancellationToken cancellationToken);
    Task<bool> DeleteTaskUseCase(Guid id, CancellationToken cancellationToken);
    Task DeleteTasksUseCase(CancellationToken cancellationToken);
}
