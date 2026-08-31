[![](https://img.shields.io/nuget/v/soenneker.github.repositories.pages.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.github.repositories.pages/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.github.repositories.pages/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.github.repositories.pages/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.github.repositories.pages.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.github.repositories.pages/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.github.repositories.pages/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.github.repositories.pages/actions/workflows/codeql.yml)

# Soenneker.GitHub.Repositories.Pages

Reads, creates, updates, and deletes GitHub Pages site configuration for a repository.

## Installation

```bash
dotnet add package Soenneker.GitHub.Repositories.Pages
```

## Configure and register

```json
{
  "GH": {
    "Token": "your-github-token"
  }
}
```

```csharp
using Soenneker.GitHub.Repositories.Pages.Registrars;

services.AddGitHubRepositoriesPagesUtilAsSingleton();
```

## Read or create a site

```csharp
Page? site = await pages.Get(
    "example-org", "example-repository", cancellationToken);

Page? created = await pages.Create(
    "example-org",
    "example-repository",
    new ReposCreatePagesSiteRequest
    {
        Source = new ReposCreatePagesSiteRequestSource
        {
            Branch = "main",
            Path = ReposCreatePagesSiteRequestSourcePath.Slash
        }
    },
    cancellationToken);
```

`Get()` returns `null` only when GitHub reports that Pages is not configured. Authentication, permission, rate-limit, and transport failures propagate. The generated request models define supported build and source settings.

`Update()` replaces the supplied Pages settings. `Delete()` removes the Pages site configuration and is destructive; repository content is separate, but the published site becomes unavailable. These operations require repository administration permission.
