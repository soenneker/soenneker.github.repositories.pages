using Microsoft.Extensions.Logging;
using Soenneker.Extensions.HttpClient;
using Soenneker.Extensions.HttpResponseMessage;
using Soenneker.Extensions.Object;
using Soenneker.Extensions.ValueTask;
using Soenneker.GitHub.Client.Http.Abstract;
using Soenneker.GitHub.Repositories.Pages.Abstract;
using Soenneker.GitHub.Repositories.Pages.Requests;
using Soenneker.GitHub.Repositories.Pages.Responses;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.GitHub.Repositories.Pages;

/// <inheritdoc cref="IGitHubRepositoriesPagesUtil"/>
public class GitHubRepositoriesPagesUtil : IGitHubRepositoriesPagesUtil
{
    private readonly ILogger<GitHubRepositoriesPagesUtil> _logger;
    private readonly IGitHubHttpClient _gitHubHttpClient;

    public GitHubRepositoriesPagesUtil(ILogger<GitHubRepositoriesPagesUtil> logger, IGitHubHttpClient gitHubHttpClient)
    {
        _logger = logger;
        _gitHubHttpClient = gitHubHttpClient;
    }

    public async ValueTask<GitHubPagesResponse?> Get(string owner, string repo, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating GitHub Pages to use GitHub Actions for repo ({owner}/{repo})...", owner, repo);

        HttpClient client = await _gitHubHttpClient.Get(cancellationToken).NoSync();

        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"repos/{owner}/{repo}/pages");

        (GitHubPagesResponse? successResponse, string? errorResponse) = await client.TrySendWithError<GitHubPagesResponse, string>(requestMessage, _logger, cancellationToken).NoSync();

        if (successResponse == null)
        {
            if (errorResponse != null)
            {
                _logger.LogError("Failed to update GitHub pages setting: {ErrorContent}", errorResponse);
            }
            else
                _logger.LogError("Failed to update GitHub pages setting");

            return null;
        }

        return successResponse;
    }

    public async ValueTask<GitHubPagesResponse?> Create(string owner, string repo, GitHubPagesCreateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating GitHub Pages to use GitHub Actions for repo ({owner}/{repo})...", owner, repo);

        HttpClient client = await _gitHubHttpClient.Get(cancellationToken).NoSync();

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"repos/{owner}/{repo}/pages");

        requestMessage.Content = request.ToHttpContent();

        (GitHubPagesResponse? successResponse, string? errorResponse) = await client.TrySendWithError<GitHubPagesResponse, string>(requestMessage, _logger, cancellationToken).NoSync();

        if (successResponse == null)
        {
            if (errorResponse != null)
            {
                _logger.LogError("Failed to update GitHub pages setting: {ErrorContent}", errorResponse);
            }
            else
                _logger.LogError("Failed to update GitHub pages setting");

            return null;
        }

        return successResponse;
    }

    public async ValueTask Update(string owner, string repo, GitHubPagesUpdateRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating GitHub Pages to use GitHub Actions for repo ({owner}/{repo})...", owner, repo);

        HttpClient client = await _gitHubHttpClient.Get(cancellationToken).NoSync();

        var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"repos/{owner}/{repo}/pages");

        requestMessage.Content = request.ToHttpContent();

        (bool successful, HttpResponseMessage? response) = await client.TrySend(requestMessage, _logger, cancellationToken).NoSync();

        if (!successful)
        {
            if (response != null)
            {
                string? errorContent = await response.ToStringSafe(_logger, cancellationToken).NoSync();
                _logger.LogError("Failed to update GitHub pages setting: {StatusCode} - {ErrorContent}", response.StatusCode, errorContent);
            }
            else
                _logger.LogError("Failed to update GitHub pages setting");
        }
    }

    public async ValueTask Delete(string owner, string repo, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating GitHub Pages to use GitHub Actions for repo ({owner}/{repo})...", owner, repo);

        HttpClient client = await _gitHubHttpClient.Get(cancellationToken).NoSync();

        var requestMessage = new HttpRequestMessage(HttpMethod.Delete, $"repos/{owner}/{repo}/pages");

        (bool successful, HttpResponseMessage? response) = await client.TrySend(requestMessage, _logger, cancellationToken).NoSync();

        if (!successful)
        {
            if (response != null)
            {
                string? errorContent = await response.ToStringSafe(_logger, cancellationToken).NoSync();
                _logger.LogError("Failed to update GitHub pages setting: {StatusCode} - {ErrorContent}", response.StatusCode, errorContent);
            }
            else
                _logger.LogError("Failed to update GitHub pages setting");
        }
    }
}