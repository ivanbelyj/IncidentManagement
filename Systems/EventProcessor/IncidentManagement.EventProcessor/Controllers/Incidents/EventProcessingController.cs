using AutoMapper;
using IncidentManagement.EventProcessor.Controllers.Incidents.Models;
using IncidentManagement.Services.EventsProcessing;
using IncidentManagement.Services.EventsProcessing.Models;
using Microsoft.AspNetCore.Mvc;

namespace IncidentManagement.EventProcessor.Controllers.Incidents;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/event-processing")]
[Produces("application/json")]
public class EventProcessingController : ControllerBase
{
    private readonly IEventProcessingService eventProcessing;
    private readonly IMapper mapper;

    public EventProcessingController(IEventProcessingService eventProcessing,
        IMapper mapper)
    {
        this.eventProcessing = eventProcessing;
        this.mapper = mapper;
    }

    /// <summary>
    /// Processes the created event (please, set the correct time of event creation 
    /// if you will call it in OpenApi UI or use EventsGenerator where it will
    /// be set automatically)
    /// </summary>
    [HttpPost("process-event")]
    public async Task ProcessEvent([FromBody] ProcessEventRequest request)
    {
        await eventProcessing.ProcessEvent(mapper.Map<ProcessEventModel>(request));
    }

    /// <summary>
    /// Incidents created based on the processed events
    /// </summary>
    [HttpGet("incidents")]
    public async Task<IEnumerable<IncidentResponse>> GetIncidents(
        [FromQuery] int offset = 0,
        [FromQuery] int limit = 10,
        [FromQuery] bool sorted = true,
        [FromQuery] bool orderByTimeDesc = true)
    {
        return mapper.Map<IEnumerable<IncidentResponse>>(await eventProcessing
            .GetIncidents(offset, limit, sorted, orderByTimeDesc));
    }
}
