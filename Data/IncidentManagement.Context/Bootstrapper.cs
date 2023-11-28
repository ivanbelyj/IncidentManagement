using IncidentManagement.Common.Configuration;
using IncidentManagement.Common.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Context;
public static class Bootstrapper
{
    public static IServiceCollection AddAppDbContext(
        this IServiceCollection services, IConfiguration? configuration = null)
    {
        var dbSettings = ConfigurationUtils
            .Load<DbSettings>(ConfigurationSectionKeys.DATABASE, configuration);
        ArgumentNullException.ThrowIfNull(dbSettings, nameof(dbSettings));

        //services.AddSingleton(dbSettings);

        services.AddDbContext<MainDbContext>(options =>
        {
            options.UseNpgsql(dbSettings.ConnectionString, opts => opts
                .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
                .MigrationsHistoryTable("_EFMigrationsHistory", "public")
                .MigrationsAssembly($"IncidentManagement.Context.MigrationsPostgreSQL"));
            options.EnableSensitiveDataLogging();
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        return services;
    }
}
