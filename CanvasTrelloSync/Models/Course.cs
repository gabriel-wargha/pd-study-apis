using System.Text.Json.Serialization;

namespace CanvasTrelloSync.Models;

public class Course
{
    [JsonPropertyName("id")] public long Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("course_code")] public string? CourseCode { get; set; }

    public override string ToString() => $"{CourseCode} - {Name}";
}