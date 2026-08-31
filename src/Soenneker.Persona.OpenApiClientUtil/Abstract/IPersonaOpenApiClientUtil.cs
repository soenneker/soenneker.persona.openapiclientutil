using Soenneker.Persona.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Persona.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Persona identity API client backed by the configured HTTP provider.
/// </summary>
public interface IPersonaOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Persona client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Persona client.</returns>
    ValueTask<PersonaOpenApiClient> Get(CancellationToken cancellationToken = default);
}
