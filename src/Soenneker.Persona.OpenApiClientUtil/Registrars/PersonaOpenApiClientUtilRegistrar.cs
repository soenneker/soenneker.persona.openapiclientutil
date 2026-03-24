using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Persona.HttpClients.Registrars;
using Soenneker.Persona.OpenApiClientUtil.Abstract;

namespace Soenneker.Persona.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class PersonaOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="PersonaOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddPersonaOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddPersonaOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IPersonaOpenApiClientUtil, PersonaOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="PersonaOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddPersonaOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddPersonaOpenApiHttpClientAsSingleton()
                .TryAddScoped<IPersonaOpenApiClientUtil, PersonaOpenApiClientUtil>();

        return services;
    }
}
