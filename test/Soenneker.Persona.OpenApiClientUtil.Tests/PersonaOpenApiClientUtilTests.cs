using Soenneker.Persona.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Persona.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class PersonaOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IPersonaOpenApiClientUtil _openapiclientutil;

    public PersonaOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IPersonaOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
