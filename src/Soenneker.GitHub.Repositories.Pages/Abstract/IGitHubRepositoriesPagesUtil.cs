using Soenneker.GitHub.OpenApiClient.Models;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.GitHub.OpenApiClient.Repos.Item.Item.Pages;

namespace Soenneker.GitHub.Repositories.Pages.Abstract;

/// <summary>
/// A utility library for GitHub repository Pages related operations
/// </summary>
public interface IGitHubRepositoriesPagesUtil
{
    ValueTask<Page?> Get(string owner, string repo, CancellationToken cancellationToken = default);

    ValueTask<Page?> Create(string owner, string repo, PagesPostRequestBody request, CancellationToken cancellationToken = default);

    ValueTask Update(string owner, string repo, PagesPutRequestBody request, CancellationToken cancellationToken = default);

    ValueTask Delete(string owner, string repo, CancellationToken cancellationToken = default);
}