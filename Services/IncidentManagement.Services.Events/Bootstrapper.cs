using IncidentManagement.Services.Events.Sending;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.Events;
public static class Bootstrapper
{
    public static IServiceCollection AddEventsService(
        this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddSingleton<IEventSender, HttpSender>();
        services.AddSingleton<IEventsService, EventsService>();
        return services;
    }
}
