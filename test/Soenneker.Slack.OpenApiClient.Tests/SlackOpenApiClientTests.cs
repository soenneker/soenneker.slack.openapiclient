using Soenneker.Tests.HostedUnit;

namespace Soenneker.Slack.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SlackOpenApiClientTests : HostedUnitTest
{
    public SlackOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
