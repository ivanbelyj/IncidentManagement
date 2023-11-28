using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Common.Configuration;
public static class ControllersConfiguration
{
    public static IServiceCollection AddAppControllers(
        this IServiceCollection services)
    {
        services
            .AddControllers();

        return services;
    }

    public static IEndpointRouteBuilder UseAppControllers(
        this IEndpointRouteBuilder app)
    {
        app.MapControllers();

        return app;
    }
}
