using System.ComponentModel.DataAnnotations.Schema;

namespace Dal.Entities;

public sealed class TaskEntity
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public DateTimeOffset CreatedUtc { get; set; }
    [ForeignKey("UserId")]
    public Guid CreatedByUserId { get; set; }
}
