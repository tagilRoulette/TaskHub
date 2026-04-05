namespace Api.Controllers.Users.Request;

public record SetTaskTitleRequest
{
    public string? Title { get; init; }
}