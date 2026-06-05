using Soenneker.GitHub.OpenApiClient.Models;
using System.Threading;
using System.Threading.Tasks;
namespace Soenneker.GitHub.Repositories.Pages.Abstract;

/// <summary>
/// A utility library for GitHub repository Pages related operations
/// </summary>
public interface IGitHubRepositoriesPagesUtil
{
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="owner">The owner.</param>
    /// <param name="repo">The repo.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<Page?> Get(string owner, string repo, CancellationToken cancellationToken = default);

    /// <summary>
    /// Executes the create operation.
    /// </summary>
    /// <param name="owner">The owner.</param>
    /// <param name="repo">The repo.</param>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<Page?> Create(string owner, string repo, ReposCreatePagesSite request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Executes the update operation.
    /// </summary>
    /// <param name="owner">The owner.</param>
    /// <param name="repo">The repo.</param>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    ValueTask Update(string owner, string repo, ReposUpdateInformationAboutPagesSite request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Executes the delete operation.
    /// </summary>
    /// <param name="owner">The owner.</param>
    /// <param name="repo">The repo.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    ValueTask Delete(string owner, string repo, CancellationToken cancellationToken = default);
}