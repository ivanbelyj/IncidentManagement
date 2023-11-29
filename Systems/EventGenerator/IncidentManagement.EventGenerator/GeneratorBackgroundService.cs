using IncidentManagement.Services.Events;

namespace IncidentManagement.EventGenerator;

/// <summary>
/// Background service generating random events at random time intervals
/// </summary>
public class GeneratorBackgroundService : BackgroundService
{
    private const int MAX_DELAY_MS = 2000;
    private readonly IEventsService eventsService;

    public GeneratorBackgroundService(IEventsService eventsService)
    {
        this.eventsService = eventsService;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Random rnd = new();
        while (!stoppingToken.IsCancellationRequested)
        {
            await eventsService.GenerateAndSendEvent(
                EventGenerationUtils.GetRandomGenerateEventModel());

            int randomDelay = rnd.Next(MAX_DELAY_MS + 1);
            await Task.Delay(randomDelay);
        }
    }
}
