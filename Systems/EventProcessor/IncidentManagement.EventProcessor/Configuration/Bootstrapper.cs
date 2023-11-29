using IncidentManagement.Common.Configuration;
using IncidentManagement.Common.Configuration.Settings;
using IncidentManagement.Services.EventProcessing;

namespace EventProcessor.Configuration;

public static class Bootstrapper
{
    public static IServiceCollection AddAppServices(
        this IServiceCollection services,
        IConfiguration? configuration = null)
    {
        services.AddAppOpenApiSettings(configuration);
        services.AddEventProcessingService();
        return services;
    }
}
