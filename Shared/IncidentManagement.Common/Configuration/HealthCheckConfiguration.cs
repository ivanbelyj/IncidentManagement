using IncidentManagement.Common.HealthChecks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Common.Configuration;
public static class HealthCheckConfiguration
{
    public static IServiceCollection AddAppHealthChecks(
        this IServiceCollection services, string assemblyName)
    {
        services.AddHealthChecks().AddCheck<SelfHealthCheck>(assemblyName);

        return services;
    }

    public static void UseAppHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health");  // Should not depend on the database

        app.MapHealthChecks("/health/detail", new HealthCheckOptions
        {
            ResponseWriter = HealthCheckUtils.WriteHealthCheckResponse,
            AllowCachingResponses = false,
        });
    }
}
