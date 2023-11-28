using IncidentManagement.Common.Configuration;
using IncidentManagement.Common.Configuration.Settings;

namespace EventProcessor.Configuration;

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
