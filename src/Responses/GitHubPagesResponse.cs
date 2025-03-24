using Soenneker.GitHub.Repositories.Pages.Enums;
using System;
using System.Text.Json.Serialization;
using Soenneker.GitHub.Repositories.Pages.Dtos;

namespace Soenneker.GitHub.Repositories.Pages.Responses;

/// <summary>
/// Represents the configuration for GitHub Pages for a repository.
/// </summary>
public record GitHubPagesResponse
{
    /// <summary>
    /// The API address for accessing this Page resource.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;

    /// <summary>
    /// The status of the most recent build of the Page.
    /// </summary>
    [JsonPropertyName("status")]
    public GitHubPagesStatus? Status { get; set; }

    /// <summary>
    /// The Pages site's custom domain.
    /// </summary>
    [JsonPropertyName("cname")]
    public string? CName { get; set; }

    /// <summary>
    /// The state if the domain is verified.
    /// </summary>
    [JsonPropertyName("protected_domain_state")]
    public GitHubPagesProtectedDomainState? ProtectedDomainState { get; set; }

    /// <summary>
    /// The timestamp when a pending domain becomes unverified.
    /// </summary>
    [JsonPropertyName("pending_domain_unverified_at")]
    public DateTimeOffset? PendingDomainUnverifiedAt { get; set; }

    /// <summary>
    /// Whether the Page has a custom 404 page.
    /// </summary>
    [JsonPropertyName("custom_404")]
    public bool Custom404 { get; set; }

    /// <summary>
    /// The web address the Page can be accessed from.
    /// </summary>
    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; set; }

    /// <summary>
    /// The process in which the Page will be built.
    /// </summary>
    [JsonPropertyName("build_type")]
    public GitHubPagesBuildType? BuildType { get; set; }

    /// <summary>
    /// The source configuration of the Pages site.
    /// </summary>
    [JsonPropertyName("source")]
    public GitHubPagesSource? Source { get; set; }

    /// <summary>
    /// Whether the GitHub Pages site is publicly visible.
    /// </summary>
    [JsonPropertyName("public")]
    public bool Public { get; set; }

    /// <summary>
    /// The HTTPS certificate details for the Pages site.
    /// </summary>
    [JsonPropertyName("https_certificate")]
    public GitHubPagesHttpsCertificate? HttpsCertificate { get; set; }

    /// <summary>
    /// Whether HTTPS is enabled on the domain.
    /// </summary>
    [JsonPropertyName("https_enforced")]
    public bool? HttpsEnforced { get; set; }
}