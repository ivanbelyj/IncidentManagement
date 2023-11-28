using IncidentManagement.Common.Configuration;
using IncidentManagement.Common.Configuration.Settings;

namespace EventGenerator.Configuration;

public static class Bootstrapper
{
    public static IServiceCollection AddAppServices(
        this IServiceCollection services,
        IConfiguration? configuration = null)
    {
        services.AddAppOpenApiSettings(configuration);
        return services;
    }
}
