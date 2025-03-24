using Soenneker.GitHub.Repositories.Pages.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.GitHub.Repositories.Pages.Abstract;

/// <summary>
/// A utility library for GitHub repository Pages related operations
/// </summary>
public interface IGitHubRepositoriesPagesUtil
{
    ValueTask UpdateBuildType(string owner, string repo, GitHubPagesUpdateRequest updateRequest, CancellationToken cancellationToken = default);
}