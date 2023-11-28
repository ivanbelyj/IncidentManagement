using IncidentManagement.Common.Consts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Common.Configuration.Settings;
public static class AppSettingsBootstrapper
{
    public static IServiceCollection AddAppOpenApiSettings(
        this IServiceCollection services,
        IConfiguration? configuration = null)
    {
        var openApiSettings = ConfigurationUtils.Load<OpenApiSettings>
            (ConfigurationSectionKeys.OPEN_API, configuration);
        ArgumentNullException.ThrowIfNull(openApiSettings);

        services.AddSingleton(openApiSettings);

        return services;
    }
}
