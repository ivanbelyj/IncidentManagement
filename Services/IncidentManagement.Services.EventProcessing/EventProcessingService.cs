using AutoMapper;
using IncidentManagement.Context;
using IncidentManagement.Context.Entities;
using IncidentManagement.Services.EventProcessing.Models;
using IncidentManagement.Services.EventProcessing.TemplateMatching;
using IncidentManagement.Services.EventProcessing.TemplateMatching.TemplateHandlers;
using IncidentManagement.Services.EventsProcessing;
using IncidentManagement.Services.EventsProcessing.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventProcessing;
public class EventProcessingService : IEventProcessingService
{
    private readonly MainDbContext dbContext;
    private readonly IMapper mapper;
    private readonly TemplatesMatcher matcher;
    private readonly ILogger logger;

    public EventProcessingService(MainDbContext mainDbContext, IMapper mapper,
        TemplatesMatcher matcher, ILogger logger)
    {
        this.dbContext = mainDbContext;
        this.mapper = mapper;
        this.matcher = matcher;
        this.logger = logger;
    }

    public async Task<IEnumerable<IncidentModel>> GetIncidents(
        int offset = 0,
        int limit = 10,
        bool sorted = true,
        bool orderByTimeDesc = true)
    {
        var incidents = dbContext
            .Incidents
            .Include(x => x.BaseEvents)
            .AsQueryable();

        if (sorted)
        {
            incidents = orderByTimeDesc
                ? incidents.OrderByDescending(x => x.Time)
                : incidents.OrderBy(x => x.Time);
        }
        return mapper.Map<IEnumerable<IncidentModel>>(await incidents
            .Skip(Math.Max(0, offset))
            .Take(Math.Max(0, Math.Min(1000, limit)))
            .ToListAsync());
    }

    public async Task ProcessEvent(ProcessEventModel model)
    {
        var matchingRes = matcher.MatchAndCreateIncident(model);

        if (matchingRes.IsMatched)
        {
            var incident = await AddIncident(matchingRes.AddIncidentModel!);
            await AddBaseEvents(incident.Id, matchingRes.BaseProcessEventModels!);
        }
    }

    private async Task<Incident> AddIncident(AddIncidentModel addIncidentModel)
    {
        var incident = mapper.Map<Incident>(addIncidentModel);
        await dbContext.Incidents.AddAsync(incident);
        logger.Information($"Added incident (type: {incident.Type}, "
            + $"time: {incident.Time})");

        dbContext.SaveChanges();

        return incident;
    }

    // For adding base events of the incident
    private async Task AddBaseEvents(Guid incidentId, ProcessEventModel[] models)
    {
        foreach (var model in models)
        {
            var newEvent = mapper.Map<Event>(model);
            newEvent.DerivedIncidentId = incidentId;

            await dbContext.Events.AddAsync(newEvent);
            
        }
        logger.Information($"{models.Length} base event" +
            (models.Length != 1 ? "s" : "") + " added");

        dbContext.SaveChanges();
    }
}
