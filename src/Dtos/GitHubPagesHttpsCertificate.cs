using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Soenneker.GitHub.Repositories.Pages.Enums;

namespace Soenneker.GitHub.Repositories.Pages.Dtos;

/// <summary>
/// Represents the HTTPS certificate information for the Pages site.
/// </summary>
public class GitHubPagesHttpsCertificate
{
    /// <summary>
    /// The current state of the certificate.
    /// </summary>
    [JsonPropertyName("state")]
    public GitHubPagesCertificateState State { get; set; } = null!;

    /// <summary>
    /// A textual description of the certificate status.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Domains covered by this certificate.
    /// </summary>
    [JsonPropertyName("domains")]
    public List<string> Domains { get; set; } = new();

    /// <summary>
    /// Expiration date of the certificate, if available.
    /// </summary>
    [JsonPropertyName("expires_at")]
    public DateTimeOffset? ExpiresAt { get; set; }
}