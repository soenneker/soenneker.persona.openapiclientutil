using Soenneker.Persona.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Persona.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class PersonaOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IPersonaOpenApiClientUtil _openapiclientutil;

    public PersonaOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IPersonaOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
