using Intellenum;

namespace Soenneker.GitHub.Repositories.Pages.Enums;

/// <summary>
/// Represents the status of the most recent GitHub Pages build.
/// </summary>
[Intellenum<string>]
public partial class GitHubPagesStatus
{
    public static readonly GitHubPagesStatus Built = new("built");
    public static readonly GitHubPagesStatus Building = new("building");
    public static readonly GitHubPagesStatus Errored = new("errored");
}