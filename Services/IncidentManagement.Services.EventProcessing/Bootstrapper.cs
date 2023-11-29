using IncidentManagement.Services.EventProcessing.TemplateMatching.TemplateHandlers;
using IncidentManagement.Services.EventProcessing.TemplateMatching;
using IncidentManagement.Services.EventsProcessing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileSystemGlobbing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventProcessing;
public static class Bootstrapper
{
    public static IServiceCollection AddEventProcessingService(
        this IServiceCollection services)
    {
        
        var matcher = new TemplatesMatcher(new ITemplateHandler[]
        {
            new CompositeTemplateHandler(),
            new SimpleTemplateHandler(),
        });
        services.AddSingleton(matcher);
        services.AddScoped<IEventProcessingService, EventProcessingService>();
        return services;
    }
}
