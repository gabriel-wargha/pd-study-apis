using System.Text.Json.Serialization;

namespace CanvasTrelloSync.Models;

public class Submission
{
    [JsonPropertyName("workflow_state")] public string? WorkflowState { get; set; }
}