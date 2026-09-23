using System.Text.Json.Serialization;

namespace CanvasTrelloSync.Models;

public class Assignment
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("html_url")] public string? Url { get; set; }
    [JsonPropertyName("due_at")] public DateTimeOffset? DueAt { get; set; }

    [JsonPropertyName("points_possible")] public double? Points { get; set; }

}