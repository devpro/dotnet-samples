# .NET 8 samples

## New features

[What's new in .NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8/overview)

## Local development

Check code style:

```bash
dotnet format
```

Build the solution:

```bash
dotnet build
```

Run the samples:

```bash
# runs a local MongoDB in a container
docker run --name mongodb6 -d -p 27017:27017 mongo:6.0

# runs blog Blazor application (click on the link to open the website in your browser)
dotnet run --project src/BlogBlazorApp
```
