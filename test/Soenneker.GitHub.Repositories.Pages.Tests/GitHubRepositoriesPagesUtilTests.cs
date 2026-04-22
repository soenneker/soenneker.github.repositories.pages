using Soenneker.GitHub.Repositories.Pages.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.GitHub.Repositories.Pages.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class GitHubRepositoriesPagesUtilTests : HostedUnitTest
{
    private readonly IGitHubRepositoriesPagesUtil _util;

    public GitHubRepositoriesPagesUtilTests(Host host) : base(host)
    {
        _util = Resolve<IGitHubRepositoriesPagesUtil>(true);
    }

    [Test]
    public void Default()
    {
    }

}