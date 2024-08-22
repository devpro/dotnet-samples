using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DotnetSamples.BlogBlazorApp.DependencyInjection;

internal static class ServiceCollectionExtensions
{
    /// <summary>
    /// Create mapper (AutoMapper) and add it in services.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    internal static IServiceCollection AddMapping(this IServiceCollection services)
    {
        // creates mapper (AutoMapper) and adds it as a service
        var mappingConfig = new MapperConfiguration(x =>
        {
            x.AddProfile(new BlogInfraMongoDb.Mapping.BlogMappingProfile());
            x.CreateMap<MongoDB.Bson.ObjectId, string>().ConvertUsing<BlogInfraMongoDb.Mapping.ObjectIdToStringConverter>();
            x.CreateMap<string, MongoDB.Bson.ObjectId>().ConvertUsing<BlogInfraMongoDb.Mapping.StringToObjectIdConverter>();
            x.AllowNullCollections = true;
        });
        var mapper = mappingConfig.CreateMapper();
        mapper.ConfigurationProvider.AssertConfigurationIsValid();
        services.AddSingleton(mapper);

        return services;
    }

    /// <summary>
    /// Add infrastructure providers add it in services.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configurationRoot"></param>
    /// <returns></returns>
    internal static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationRoot configurationRoot)
    {
        var connectionString = GetConnectionString(configurationRoot, "MongoDb:ConnectionStringName");
        var databaseName = GetSection(configurationRoot, "MongoDb:DatabaseName");
        services.AddDbContext<BlogInfraMongoDb.BlogDbContext>(
            options => options.UseMongoDB(connectionString, databaseName));
        services.TryAddScoped<BlogDomain.Repositories.IBlogRepository, BlogInfraMongoDb.BlogRepository>();

        return services;
    }

    private static string GetSection(IConfigurationRoot configurationRoot, string sectionKey)
    {
        return configurationRoot.GetSection(sectionKey)?.Get<string>()
            ?? throw new ArgumentException($"Missing section \"{sectionKey}\" in configuration", nameof(sectionKey));
    }

    private static string GetConnectionString(IConfigurationRoot configurationRoot, string sectionKey)
    {
        var section = GetSection(configurationRoot, sectionKey);
        return configurationRoot.GetConnectionString(section)
            ?? throw new ArgumentException($"Missing connection string \"{sectionKey}\" in configuration", nameof(sectionKey));
    }
}
