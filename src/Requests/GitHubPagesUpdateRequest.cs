using System.Text.Json.Serialization;

namespace Soenneker.GitHub.Repositories.Pages.Requests;

public record GitHubPagesUpdateRequest
{
    /// <summary>
    /// "workflow" = from action
    /// "legacy"
    /// </summary>
    [JsonPropertyName("build_type")]
    public string BuildType { get; set; } = null!;
}