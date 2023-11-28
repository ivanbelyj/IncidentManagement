using AutoMapper;
using IncidentManagement.Common.Enums;
using IncidentManagement.Services.Events.Models;

namespace EventGenerator.Controllers.Events.Models;

public class EventResponse
{
    public Guid Id { get; set; }
    public EventType Type { get; set; }
    public DateTime Time { get; set; }
}

public class EventResponseProfile : Profile
{
    public EventResponseProfile()
    {
        CreateMap<EventModel, EventResponse>();
    }
}

