using Soenneker.GitHub.OpenApiClient.Models;
using System.Threading;
using System.Threading.Tasks;
namespace Soenneker.GitHub.Repositories.Pages.Abstract;

/// <summary>
/// A utility library for GitHub repository Pages related operations
/// </summary>
public interface IGitHubRepositoriesPagesUtil
{
    ValueTask<Page?> Get(string owner, string repo, CancellationToken cancellationToken = default);

    ValueTask<Page?> Create(string owner, string repo, ReposCreatePagesSite request, CancellationToken cancellationToken = default);

    ValueTask Update(string owner, string repo, ReposUpdateInformationAboutPagesSite request, CancellationToken cancellationToken = default);

    ValueTask Delete(string owner, string repo, CancellationToken cancellationToken = default);
}