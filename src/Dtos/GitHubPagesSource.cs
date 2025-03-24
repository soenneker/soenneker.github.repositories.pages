using System.Text.Json.Serialization;

namespace Soenneker.GitHub.Repositories.Pages.Dtos;

/// <summary>
/// Represents the source configuration for a GitHub Pages site.
/// </summary>
public record GitHubPagesSource
{
    /// <summary>
    /// The repository branch used to publish your site's source files.
    /// This field is required.
    /// </summary>
    [JsonPropertyName("branch")]
    public string Branch { get; set; } = null!;

    /// <summary>
    /// The repository directory that includes the source files for the Pages site.
    /// Allowed values: "/", "/docs".
    /// This field is required.
    /// </summary>
    [JsonPropertyName("path")]
    public string Path { get; set; } = null!;
}