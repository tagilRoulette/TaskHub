using System.Text.Json.Serialization;
using Api.Converters;

namespace Api.Controllers.Tasks.Request;
public record CreateTaskRequest
{
    public string? Title { get; init; }

    [JsonPropertyName("CreatedByUserId")]
    [JsonConverter(typeof(StringToGuidConverter))]
    public Guid? CreatedByUserId { get; init; }
}
