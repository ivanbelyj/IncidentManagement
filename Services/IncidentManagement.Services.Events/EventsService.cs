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
    public Task<EventModel> GenerateAndSendEvent(GenerateEventModel model)
    {
        // No need to map it to Event because we don't add the event
        // to the database in this service
        //var generatedEvent = mapper.Map<Event>(model);
        var generatedEvent = mapper.Map<EventModel>(model);
        generatedEvent.Time = DateTime.UtcNow;

        // Now the generated event has no Id

        // Todo: send
        logger.Information($"Event generated (type: {generatedEvent.Type},"
            + $" time: {generatedEvent.Time})");

        return Task.FromResult(generatedEvent);
    }
}
