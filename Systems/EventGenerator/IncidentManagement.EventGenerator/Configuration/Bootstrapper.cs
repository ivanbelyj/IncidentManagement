using IncidentManagement.Common.Configuration;
using IncidentManagement.Common.Configuration.Settings;
using IncidentManagement.EventGenerator;
using IncidentManagement.Services.Events;

namespace EventGenerator.Configuration;

public static class Bootstrapper
{
    public static IServiceCollection AddAppServices(
        this IServiceCollection services,
        IConfiguration? configuration = null)
    {
        services.AddAppOpenApiSettings(configuration);
        services.AddGeneratorSettings(configuration);

        services.AddEventsService();
        services.AddHostedService<GeneratorBackgroundService>();

        return services;
    }
}
