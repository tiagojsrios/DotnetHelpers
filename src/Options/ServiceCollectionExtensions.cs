using Microsoft.Extensions.DependencyInjection;

namespace DotnetHelpers.Options;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOptionsAndValidate<TOptions>(this IServiceCollection services, string? configurationName = null)
        where TOptions : class
    {
        configurationName ??= typeof(TOptions).Name;

        services.AddOptions<TOptions>()
            .BindConfiguration(configurationName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
}