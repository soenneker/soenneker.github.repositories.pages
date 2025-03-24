using Intellenum;

namespace Soenneker.GitHub.Repositories.Pages.Enums;

/// <summary>
/// Represents the verification state of a custom domain.
/// </summary>
[Intellenum<string>]
public partial class GitHubPagesProtectedDomainState
{
    public static readonly GitHubPagesProtectedDomainState Pending = new("pending");
    public static readonly GitHubPagesProtectedDomainState Verified = new("verified");
    public static readonly GitHubPagesProtectedDomainState Unverified = new("unverified");
}