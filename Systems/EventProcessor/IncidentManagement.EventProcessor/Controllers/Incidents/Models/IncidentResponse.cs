using AutoMapper;
using IncidentManagement.Common.Enums;
using IncidentManagement.Services.EventProcessing.Models;

namespace IncidentManagement.EventProcessor.Controllers.Incidents.Models;

public class IncidentResponse
{
    public Guid Id { get; set; }
    public IncidentType Type { get; set; }
    public DateTime Time { get; set; }
    public ICollection<EventModel>? BaseEvents { get; set; }
}

public class IncidentResponseProfile : Profile
{
    public IncidentResponseProfile()
    {
        CreateMap<IncidentModel, IncidentResponse>();
    }
}
