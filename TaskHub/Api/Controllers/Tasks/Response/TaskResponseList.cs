namespace Api.Controllers.Tasks.Response
{
    public record TaskResponseList(IReadOnlyCollection<TaskResponse> Tasks);
}
