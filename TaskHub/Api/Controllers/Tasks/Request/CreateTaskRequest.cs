namespace Api.Controllers.Tasks.Request;
    public record CreateTaskRequest(Guid Id,
                                    string? Title,
                                    Guid CreatedByUserId,
                                    DateTimeOffset CreatedUtc);
