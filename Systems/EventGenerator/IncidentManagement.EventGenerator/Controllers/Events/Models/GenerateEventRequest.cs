using AutoMapper;
using IncidentManagement.Common.Enums;
using IncidentManagement.Services.Events.Models;

namespace EventGenerator.Controllers.Events.Models;

public class GenerateEventRequest
{
    public EventType Type { get; set; }
}

public class GenerateEventRequestProfile : Profile
{
	public GenerateEventRequestProfile()
	{
		CreateMap<GenerateEventRequest, GenerateEventModel>();
	}
}
