using Soenneker.GitHub.OpenApiClient.Repos.Item.Item.Pages;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Task;
using Soenneker.Extensions.ValueTask;
using Soenneker.GitHub.ClientUtil.Abstract;
using Soenneker.GitHub.OpenApiClient;
using Soenneker.GitHub.OpenApiClient.Models;
using Soenneker.GitHub.Repositories.Pages.Abstract;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.GitHub.Repositories.Pages;

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
        catch (BasicError ex) when (ex.ResponseStatusCode == 404)
        {
            _logger.LogDebug("GitHub Pages is not configured for {owner}/{repo}", owner, repo);
            return null;
        }
    }

    public async ValueTask<Page?> Create(string owner, string repo, ReposCreatePagesSiteRequest request, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Creating GitHub Pages site for repo ({owner}/{repo})...", owner, repo);

        GitHubOpenApiClient client = await _gitHubClientUtil.Get(cancellationToken).NoSync();
        PagesRequestBuilder? pagesClient = client.Repos[owner][repo].Pages;

        return await pagesClient.PostAsync(request, cancellationToken: cancellationToken).NoSync();
    }

    public async ValueTask Update(string owner, string repo, ReposUpdateInformationAboutPagesSiteRequest request, CancellationToken cancellationToken = default)
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
