using IncidentManagement.Common.Configuration.Settings;
using IncidentManagement.Services.Events.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IncidentManagement.Services.Events.Sending;
public class HttpSender : IEventSender
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly GeneratorSettings generatorSettings;
    private readonly ILogger logger;

    public HttpSender(IHttpClientFactory httpClientFactory,
        GeneratorSettings generatorSettings,
        ILogger logger)
    {
        this.httpClientFactory = httpClientFactory;
        this.generatorSettings = generatorSettings;
        this.logger = logger;
    }
    public async Task Send(EventModel eventModel)
    {
        var httpClient = httpClientFactory.CreateClient();
        string apiUrl = generatorSettings.EventProcessingUrl;
        string json = JsonSerializer.Serialize(eventModel);

        HttpContent content = new StringContent(json, Encoding.UTF8,
            "application/json");

        HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Error on sending event: {response.StatusCode}");
        }
    }
}
