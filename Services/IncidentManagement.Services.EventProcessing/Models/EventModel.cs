using AutoMapper;
using IncidentManagement.Common.Enums;
using IncidentManagement.Context.Entities;

namespace IncidentManagement.Services.EventProcessing.Models;

/// <summary>
/// DTO of the incident base event stored in the database
/// </summary>
public class EventModel
{
    public Guid Id { get; set; }
    public EventType Type { get; set; }
    public DateTime Time { get; set; }
}


public class EventModelProfile : Profile
{
    public EventModelProfile()
    {
        CreateMap<Event, EventModel>();
    }
}
