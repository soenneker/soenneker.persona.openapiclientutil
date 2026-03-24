using Soenneker.Persona.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Persona.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IPersonaOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<PersonaOpenApiClient> Get(CancellationToken cancellationToken = default);
}
