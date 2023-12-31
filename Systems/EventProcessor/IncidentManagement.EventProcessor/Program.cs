using EventProcessor.Configuration;
using IncidentManagement.Common.Configuration;
using IncidentManagement.Common.Configuration.Settings;
using IncidentManagement.Common.Consts;
using IncidentManagement.Context;
using IncidentManagement.Context.Setup;
using System.Reflection;

const string appTitle = "IncidentManagement EventProcessor";

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

// Add services to the container.

var services = builder.Services;

var openApiSettings = ConfigurationUtils
    .Load<OpenApiSettings>(ConfigurationSectionKeys.OPEN_API);
ArgumentNullException.ThrowIfNull(openApiSettings);

services.AddAppHealthChecks(Assembly.GetExecutingAssembly().GetName().Name!);

services.AddAppDbContext(builder.Configuration);

services.AddAppVersioning();
services.AddAppOpenApi(openApiSettings, appTitle);
services.AddAppAutoMapper();
services.AddAppControllers();

services.AddAppServices(builder.Configuration);


var app = builder.Build();

DbInitializer.Initialize(app.Services);


// Configure the HTTP request pipeline.

app.UseAppHealthChecks();
app.UseAppOpenApi(appTitle);

app.UseAppControllers();

app.Run();
