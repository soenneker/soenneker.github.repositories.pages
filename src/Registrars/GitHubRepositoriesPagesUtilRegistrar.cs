using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.GitHub.Client.Http.Registrars;
using Soenneker.GitHub.Repositories.Pages.Abstract;

namespace Soenneker.GitHub.Repositories.Pages.Registrars;

/// <summary>
/// A utility library for GitHub repository Pages related operations
/// </summary>
public static class GitHubRepositoriesPagesUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IGitHubRepositoriesPagesUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddGitHubRepositoriesPagesUtilAsSingleton(this IServiceCollection services)
    {
        services.AddGitHubHttpClientAsSingleton().TryAddSingleton<IGitHubRepositoriesPagesUtil, GitHubRepositoriesPagesUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IGitHubRepositoriesPagesUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddGitHubRepositoriesPagesUtilAsScoped(this IServiceCollection services)
    {
        services.AddGitHubHttpClientAsSingleton().TryAddScoped<IGitHubRepositoriesPagesUtil, GitHubRepositoriesPagesUtil>();

        return services;
    }
}