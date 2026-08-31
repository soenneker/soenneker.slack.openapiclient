[![](https://img.shields.io/nuget/v/soenneker.slack.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.slack.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.slack.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.slack.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.slack.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.slack.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.slack.openapiclient/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.slack.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Slack.OpenApiClient

Generated Slack Web API client for conversations, messages, files, users, teams, reactions, reminders, bookmarks, canvases, lists, workflows, apps, and administration.

## Installation

```bash
dotnet add package Soenneker.Slack.OpenApiClient
```

For application registration, configuration-based authentication, and multi-workspace client caching, use `Soenneker.Slack.OpenApiClientUtil`. Instantiate this package directly when you need to supply your own Kiota request adapter.

## Usage

```csharp
using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Slack.OpenApiClient;
using Soenneker.Slack.OpenApiClient.Models;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://slack.com/")
};
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", botToken);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient)
{
    BaseUrl = httpClient.BaseAddress.ToString().TrimEnd('/')
};

var slack = new SlackOpenApiClient(adapter);
AuthTestResponse? identity = await slack.Api.AuthTest.PostAsync(
    new AuthTestRequest(),
    cancellationToken: cancellationToken);
```

Slack methods are exposed under `client.Api` using their Web API names without punctuation, such as `AuthTest`, `ConversationsList`, and `ChatPostMessage`. The token must include every scope required by the method being called.
