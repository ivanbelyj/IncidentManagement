using IncidentManagement.Common.Configuration.Settings;
using IncidentManagement.Common.Configuration;
using Microsoft.Extensions.Configuration;
using EventGenerator.Configuration;
using IncidentManagement.Common.Consts;
using System.Reflection;

const string appTitle = "IncidentManagement EventGenerator";

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

// Add services to the container.

var services = builder.Services;

var openApiSettings = ConfigurationUtils
    .Load<OpenApiSettings>(ConfigurationSectionKeys.OPEN_API);
ArgumentNullException.ThrowIfNull(openApiSettings);

services.AddAppHealthChecks(Assembly.GetExecutingAssembly().GetName().Name!);

services.AddAppVersioning();
services.AddAppOpenApi(openApiSettings, appTitle);
services.AddAppAutoMapper();
services.AddAppControllers();

services.AddAppServices(builder.Configuration);


var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseAppHealthChecks();
app.UseAppOpenApi(appTitle);

app.UseAppControllers();

app.Run();
