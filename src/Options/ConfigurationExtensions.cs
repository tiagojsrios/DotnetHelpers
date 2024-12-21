using Microsoft.Extensions.Configuration;

namespace DotnetHelpers.Options;

public static class ConfigurationExtensions
{
    /// <summary>
    /// Attempts to create an instance of <typeparam name="T"></typeparam> from the configuration section specified in the method implemented from the <see cref="INamedOptions"/> interface.
    /// </summary>
    /// <exception cref="InvalidOperationException">Exception thrown when the result of the bind attempt is null.</exception>
    public static T GetOptionsInstance<T>(this IConfiguration configuration, string? configurationSectionName = null) 
    {
        configurationSectionName ??= typeof(T).Name;
        
        return configuration
            .GetRequiredSection(configurationSectionName)
            .Get<T>() ?? throw new InvalidOperationException($"Configuration section {configurationSectionName} could not be bind to type {typeof(T)}. Check your appsettings file.");
    }
}