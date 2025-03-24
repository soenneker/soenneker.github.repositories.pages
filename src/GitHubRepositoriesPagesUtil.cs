using Microsoft.Extensions.Logging;
using Soenneker.Extensions.HttpClient;
using Soenneker.Extensions.HttpResponseMessage;
using Soenneker.Extensions.Object;
using Soenneker.Extensions.ValueTask;
using Soenneker.GitHub.Client.Http.Abstract;
using Soenneker.GitHub.Repositories.Pages.Abstract;
using Soenneker.GitHub.Repositories.Pages.Requests;
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

    public async ValueTask UpdateBuildType(string owner, string repo, GitHubPagesUpdateRequest updateRequest, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating GitHub Pages to use GitHub Actions for repo ({owner}/{repo})...", owner, repo);

        HttpClient client = await _gitHubHttpClient.Get(cancellationToken).NoSync();

        var request = new HttpRequestMessage(HttpMethod.Put, $"repos/{owner}/{repo}/pages");

        request.Content = updateRequest.ToHttpContent();

        (bool successful, HttpResponseMessage? response) = await client.TrySend(request, _logger, cancellationToken).NoSync();

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