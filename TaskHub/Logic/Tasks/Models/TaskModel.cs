namespace Logic.Tasks.Models;

public sealed class TaskModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public DateTimeOffset CreatedUtc { get; set; }
    public Guid CreatedByUserId { get; set; }

    public TaskModel(Guid id, string? title, DateTimeOffset createdUtc, Guid createdByUserId)
    {
        Id = id;
        Title = title;
        CreatedUtc = createdUtc;
        CreatedByUserId = createdByUserId;
    }
}
