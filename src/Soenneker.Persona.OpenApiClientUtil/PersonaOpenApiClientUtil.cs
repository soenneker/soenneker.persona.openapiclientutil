using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Persona.HttpClients.Abstract;
using Soenneker.Persona.OpenApiClient;
using Soenneker.Persona.OpenApiClientUtil.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Persona.OpenApiClientUtil;

public sealed class PersonaOpenApiClientUtil : IPersonaOpenApiClientUtil
{
    private readonly AsyncSingleton<PersonaOpenApiClient> _client;

    public PersonaOpenApiClientUtil(IPersonaOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<PersonaOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

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
