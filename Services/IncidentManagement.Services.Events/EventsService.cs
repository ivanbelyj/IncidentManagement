using AutoMapper;
using IncidentManagement.Context.Entities;
using IncidentManagement.Services.Events.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.Events;
public class EventsService : IEventsService
{
    private readonly IMapper mapper;
    private readonly ILogger logger;

    public EventsService(IMapper mapper, ILogger logger)
    {
        this.mapper = mapper;
        this.logger = logger;
    }
    public async Task<EventModel> GenerateEvent(GenerateEventModel model)
    {
        var generatedEvent = mapper.Map<Event>(model);

        // Todo: send
        logger.Information($"Event of (type: {generatedEvent.Type}) is generated");

        return mapper.Map<EventModel>(generatedEvent);
    }
}
