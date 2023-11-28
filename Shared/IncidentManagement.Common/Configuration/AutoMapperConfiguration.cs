using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Common.Configuration;
public static class AutoMapperConfiguration
{
    public static void AddAppAutoMapper(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(s => s.FullName != null
                && s.FullName.ToLower().StartsWith("incidentmanagement."));

        services.AddAutoMapper(assemblies);
    }
}
