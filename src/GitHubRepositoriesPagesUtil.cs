using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using Soenneker.GitHub.ClientUtil.Abstract;
using Soenneker.GitHub.OpenApiClient;
using Soenneker.GitHub.OpenApiClient.Models;
using Soenneker.GitHub.OpenApiClient.Repos.Item.Item.Pages;
using Soenneker.GitHub.Repositories.Pages.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.GitHub.Repositories.Pages;

/// <inheritdoc cref="IGitHubRepositoriesPagesUtil"/>
public sealed class GitHubRepositoriesPagesUtil : IGitHubRepositoriesPagesUtil
{
    private readonly ILogger<GitHubRepositoriesPagesUtil> _logger;
    private readonly IGitHubOpenApiClientUtil _gitHubClientUtil;

    public GitHubRepositoriesPagesUtil(ILogger<GitHubRepositoriesPagesUtil> logger, IGitHubOpenApiClientUtil gitHubClientUtil)
    {
        _logger = logger;
        _gitHubClientUtil = gitHubClientUtil;
    }

    public async ValueTask<Page?> Get(string owner, string repo, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Getting GitHub Pages information for repo ({owner}/{repo})...", owner, repo);

        GitHubOpenApiClient client = await _gitHubClientUtil.Get(cancellationToken).NoSync();
        PagesRequestBuilder? pagesClient = client.Repos[owner][repo].Pages;

        try
        {
            Page? page = await pagesClient.GetAsync(cancellationToken: cancellationToken).NoSync();
            return page;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get GitHub pages information");
            return null;
        }
    }

    public async ValueTask<Page?> Create(string owner, string repo, PagesPostRequestBody request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Creating GitHub Pages site for repo ({owner}/{repo})...", owner, repo);

        GitHubOpenApiClient client = await _gitHubClientUtil.Get(cancellationToken).NoSync();
        PagesRequestBuilder? pagesClient = client.Repos[owner][repo].Pages;

        try
        {
            Page? page = await pagesClient.PostAsync(request, cancellationToken: cancellationToken).NoSync();
            return page;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create GitHub pages site");
            return null;
        }
    }

    public async ValueTask Update(string owner, string repo, PagesPutRequestBody request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Updating GitHub Pages site for repo ({owner}/{repo})...", owner, repo);

        GitHubOpenApiClient client = await _gitHubClientUtil.Get(cancellationToken).NoSync();
        PagesRequestBuilder? pagesClient = client.Repos[owner][repo].Pages;

        try
        {
            await pagesClient.PutAsync(request, cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update GitHub pages site");
            throw;
        }
    }

    public async ValueTask Delete(string owner, string repo, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Deleting GitHub Pages site for repo ({owner}/{repo})...", owner, repo);

        GitHubOpenApiClient client = await _gitHubClientUtil.Get(cancellationToken).NoSync();
        PagesRequestBuilder? pagesClient = client.Repos[owner][repo].Pages;

        try
        {
            await pagesClient.DeleteAsync(cancellationToken: cancellationToken).NoSync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete GitHub pages site");
            throw;
        }
    }
}