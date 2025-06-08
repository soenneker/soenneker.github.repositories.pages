using Soenneker.GitHub.Repositories.Pages.Abstract;
using Soenneker.Tests.FixturedUnit;
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

}