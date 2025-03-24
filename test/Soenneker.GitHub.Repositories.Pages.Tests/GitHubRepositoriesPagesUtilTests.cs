using Soenneker.GitHub.Repositories.Pages.Abstract;
using Soenneker.Tests.FixturedUnit;
using System.Threading.Tasks;
using Soenneker.Facts.Local;
using Soenneker.GitHub.Repositories.Pages.Enums;
using Soenneker.GitHub.Repositories.Pages.Requests;
using Xunit;

namespace Soenneker.GitHub.Repositories.Pages.Tests;

[Collection("Collection")]
public class GitHubRepositoriesPagesUtilTests : FixturedUnitTest
{
    private readonly IGitHubRepositoriesPagesUtil _util;

    public GitHubRepositoriesPagesUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IGitHubRepositoriesPagesUtil>(true);
    }

    [Fact]
    public void Default()
    {
    }

    [LocalFact]
    public async ValueTask UpdateBuildType_should_update()
    {
        var createResponse = await _util.Create("soenneker", "soenneker.blazor.stripe.elements",
            new GitHubPagesCreateRequest {BuildType = GitHubPagesBuildType.Workflow}, CancellationToken);

        var updateResponse = await _util.Get("soenneker", "soenneker.blazor.stripe.elements", CancellationToken);

        await _util.Update("soenneker", "soenneker.blazor.stripe.elements", new GitHubPagesUpdateRequest {BuildType = GitHubPagesBuildType.Workflow},
            CancellationToken);
    }
}