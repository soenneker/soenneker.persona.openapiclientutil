[![](https://img.shields.io/nuget/v/soenneker.persona.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.persona.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.persona.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.persona.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.persona.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.persona.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.persona.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.persona.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Persona.OpenApiClientUtil

Provides a configured Persona identity API client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.Persona.OpenApiClientUtil
```

## Configuration

```json
{
  "Persona": {
    "ApiKey": "your-api-key"
  }
}
```

`Persona:ApiVersion` can override the packaged schema's `2025-12-08` default.

## Usage

```csharp
using Soenneker.Persona.OpenApiClientUtil.Abstract;
using Soenneker.Persona.OpenApiClientUtil.Registrars;

services.AddPersonaOpenApiClientUtilAsSingleton();

IPersonaOpenApiClientUtil persona = serviceProvider
    .GetRequiredService<IPersonaOpenApiClientUtil>();

var client = await persona.Get(cancellationToken);
var accounts = await client.Accounts.GetAsync(cancellationToken: cancellationToken);
```

Use `AddPersonaOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying authenticated HTTP provider remains shared and is disposed by the service container at shutdown.
