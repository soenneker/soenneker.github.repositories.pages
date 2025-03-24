using Soenneker.GitHub.Repositories.Pages.Requests;
using Soenneker.GitHub.Repositories.Pages.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.GitHub.Repositories.Pages.Abstract;

/// <summary>
/// A utility library for GitHub repository Pages related operations
/// </summary>
public interface IGitHubRepositoriesPagesUtil
{
    ValueTask<GitHubPagesResponse?> Get(string owner, string repo, CancellationToken cancellationToken = default);

    ValueTask<GitHubPagesResponse?> Create(string owner, string repo, GitHubPagesCreateRequest request, CancellationToken cancellationToken = default);

    ValueTask Update(string owner, string repo, GitHubPagesUpdateRequest request, CancellationToken cancellationToken = default);

    ValueTask Delete(string owner, string repo, CancellationToken cancellationToken = default);
}