using Intellenum;

namespace Soenneker.GitHub.Repositories.Pages.Enums;

/// <summary>
/// Represents the type of process used to build a GitHub Pages site.
/// </summary>
[Intellenum<string>]
public partial class GitHubPagesBuildType
{
    /// <summary>
    /// The site is built by GitHub when changes are pushed to a specific branch.
    /// </summary>
    public static readonly GitHubPagesBuildType Legacy = new("legacy");

    /// <summary>
    /// The site is built using a custom GitHub Actions workflow.
    /// </summary>
    public static readonly GitHubPagesBuildType Workflow = new("workflow");
}