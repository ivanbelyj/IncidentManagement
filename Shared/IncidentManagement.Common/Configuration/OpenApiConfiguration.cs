using IncidentManagement.Common.Configuration.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace IncidentManagement.Common.Configuration;

// The OpenApi can be configured individually for each service,
// but I created a common default configuration in this project
public static class OpenApiConfiguration
{
    public static IServiceCollection AddAppOpenApi(this IServiceCollection services,
        OpenApiSettings openApiSettings, string appTitle)
    {
        if (!openApiSettings.Enabled)
            return services;

        services
            .AddOptions<SwaggerGenOptions>()
            .Configure<IApiVersionDescriptionProvider>((options, provider) =>
            {
                foreach (var avd in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(avd.GroupName, new OpenApiInfo
                    {
                        Version = avd.GroupName,
                        Title = $"{appTitle}"
                    });
                }
            });

        services.AddSwaggerGen(options =>
        {
            options.SupportNonNullableReferenceTypes();

            options.UseInlineDefinitionsForEnums();

            options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            options.DescribeAllParametersInCamelCase();

            // Is's also necessary to enable the function of generating
            // a documentation file api.xml in the project properties
            var xmlFile = "api.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);

            //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            //{
            //    Name = "Bearer",
            //    Type = SecuritySchemeType.OAuth2,
            //    Scheme = "oauth2",
            //    BearerFormat = "JWT",
            //    In = ParameterLocation.Header,
            //    Flows = new OpenApiOAuthFlows
            //    {
            //        // There can be configured authorization
            //        //Password = new OpenApiOAuthFlow
            //        //{
            //        //    TokenUrl = new Uri($"{identitySettings.Url}/connect/token"),
            //        //    Scopes = new Dictionary<string, string>
            //        //    {
            //        //    }
            //        //}
            //    }
            //});

            //options.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //                Reference = new OpenApiReference
            //                {
            //                    Type = ReferenceType.SecurityScheme,
            //                    Id = "oauth2"
            //                }
            //            },
            //            new List<string>()
            //        }
            //    });

            options.UseOneOfForPolymorphism();
            options.EnableAnnotations(enableAnnotationsForInheritance: true,
                enableAnnotationsForPolymorphism: true);

            options.ExampleFilters();
        });

        services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

        services.AddSwaggerGenNewtonsoftSupport();

        return services;
    }


    public static void UseAppOpenApi(this WebApplication app, string appTitle)
    {
        var openApiSettings = app.Services.GetService<OpenApiSettings>();

        if (openApiSettings == null || !openApiSettings.Enabled)
            return;

        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

        app.UseSwagger(options =>
        {
            options.RouteTemplate = "api/{documentname}/api.yaml";
        });

        app.UseSwaggerUI(
            options =>
            {
                options.RoutePrefix = "api";
                provider.ApiVersionDescriptions.ToList().ForEach(
                    description => options.SwaggerEndpoint(
                        $"/api/{description.GroupName}/api.yaml",
                        description.GroupName.ToUpperInvariant())
                );

                options.DocExpansion(DocExpansion.List);
                options.DefaultModelsExpandDepth(-1);
                options.OAuthAppName(appTitle);

                //options.OAuthClientId(openApiSettings?.OAuthClientId ?? "");
                //options.OAuthClientSecret(openApiSettings?.OAuthClientSecret ?? "");
            }
        );
    }
}
