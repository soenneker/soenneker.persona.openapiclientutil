using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Persona.HttpClients.Abstract;
using Soenneker.Persona.OpenApiClientUtil.Abstract;
using Soenneker.Persona.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Persona.OpenApiClientUtil;

///<inheritdoc cref="IPersonaOpenApiClientUtil"/>
public sealed class PersonaOpenApiClientUtil : IPersonaOpenApiClientUtil
{
    private readonly AsyncSingleton<PersonaOpenApiClient> _client;

    public PersonaOpenApiClientUtil(IPersonaOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<PersonaOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Persona:ApiKey");
            string authHeaderValueTemplate = configuration["Persona:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new PersonaOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<PersonaOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
