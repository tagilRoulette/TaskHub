using Api.Controllers.Tasks.Request;
using Api.Controllers.Tasks.Response;
using Api.Controllers.Users.Request;
using Api.UseCases.Tasks.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Tasks;

[ApiController]
[Route("/tasks")]
public class TasksController : Controller
{
    private readonly IManageTaskUseCase _taskUseCase;

    public TasksController(IManageTaskUseCase taskUseCase)
    {
        _taskUseCase = taskUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponse>> CreateTaskAsync(
        [FromBody] CreateTaskRequest? request,
        CancellationToken cancellationToken)
    {
        var task = await _taskUseCase.CreateTaskUseCase(request.Title, request.CreatedByUserId, cancellationToken);
        return Ok(task);
    }

    [HttpGet]
    public async Task<ActionResult<TaskResponseList>> GetAllTasksAsync(
        CancellationToken cancellationToken)
    {
        var tasks = await _taskUseCase.GetTasksUseCase(cancellationToken);
        return Ok(tasks);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskResponse>> GetTaskByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var task = await _taskUseCase.GetTaskUseCase(id, cancellationToken);
        if (task is null) return NotFound();
        return Ok(task);
    }

    [HttpPut("{id:guid}/title")]
    public async Task<ActionResult<TaskResponseList>> SetTaskTitleAsync(
        [FromRoute] Guid id,
        [FromBody] SetTaskTitleRequest request,
        CancellationToken cancellationToken)
    {
        await _taskUseCase.SetTaskTitleUseCase(id, request.Title, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTaskByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var deleted = await _taskUseCase.DeleteTaskUseCase(id, cancellationToken);
        if (!deleted) return NotFound();
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAllTasksAsync(CancellationToken cancellationToken)
    {
        await _taskUseCase.DeleteTasksUseCase(cancellationToken);
        return NoContent();
    }
}
