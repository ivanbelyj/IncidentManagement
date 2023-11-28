using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Context.Setup;
public static class DbInitializer
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var scope = serviceProvider
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<MainDbContext>();

        dbContext.Database.Migrate();
    }
}
