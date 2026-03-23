namespace Api.Controllers.Tasks.Response;
public record TaskResponse(Guid Id,
                                string? Title,
                                Guid CreatedByUserId,
                                DateTimeOffset CreatedUtc);
