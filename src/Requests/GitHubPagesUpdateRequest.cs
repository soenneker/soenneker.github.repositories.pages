﻿using Soenneker.GitHub.Repositories.Pages.Enums;
using System.Text.Json.Serialization;
using Soenneker.GitHub.Repositories.Pages.Dtos;

namespace Soenneker.GitHub.Repositories.Pages.Requests;

public record GitHubPagesUpdateRequest
{
    /// <summary>
    /// Specify a custom domain for the repository. 
    /// Sending a null value will remove the custom domain.
    /// </summary>
    [JsonPropertyName("cname")]
    public string? CName { get; set; }

    /// <summary>
    /// Specify whether HTTPS should be enforced for the repository.
    /// </summary>
    [JsonPropertyName("https_enforced")]
    public bool HttpsEnforced { get; set; }

    /// <summary>
    /// The process by which the GitHub Pages site will be built.
    /// Allowed values: "legacy", "workflow".
    /// </summary>
    [JsonPropertyName("build_type")]
    public GitHubPagesBuildType BuildType { get; set; } = null!;

    /// <summary>
    /// The source configuration for the GitHub Pages site.
    /// Must include both a branch and a path.
    /// </summary>
    [JsonPropertyName("source")]
    public GitHubPagesSource? Source { get; set; }
}