using AutoMapper;
using EventGenerator.Controllers.Events.Models;
using IncidentManagement.Services.Events;
using IncidentManagement.Services.Events.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EventGenerator.Controllers.Events;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/events")]
[Produces("application/json")]
public class EventsController : ControllerBase
{
    private readonly Serilog.ILogger logger;
    private readonly IMapper mapper;
    private readonly IEventsService eventsService;

    public EventsController(Serilog.ILogger logger, IMapper mapper,
        IEventsService eventsService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.eventsService = eventsService;
    }

    [HttpPost("")]
    public async Task<EventResponse> GenerateEvent(
        [FromBody] GenerateEventRequest request)
    {
        var eventModel = await eventsService
            .GenerateEvent(mapper.Map<GenerateEventModel>(request));
        return mapper.Map<EventResponse>(eventModel);
    }
}
