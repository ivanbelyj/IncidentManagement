using AutoMapper;
using IncidentManagement.Common.Enums;
using IncidentManagement.Services.EventsProcessing.Models;

namespace IncidentManagement.EventProcessor.Controllers.Incidents.Models;

public class ProcessEventRequest
{
    public EventType Type { get; set; }
    public DateTime Time { get; set; }
}

public class ProcessEventRequestProfile : Profile
{
    public ProcessEventRequestProfile()
    {
        CreateMap<ProcessEventRequest, ProcessEventModel>();
    }
}
