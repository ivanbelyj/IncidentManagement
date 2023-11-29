using AutoMapper;
using IncidentManagement.Common.Enums;
using IncidentManagement.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.Events.Models;
public class GenerateEventModel
{
    public EventType Type { get; set; }
}

public class GenerateEventModelProfile : Profile
{
	public GenerateEventModelProfile()
	{
		CreateMap<GenerateEventModel, EventModel>();
	}
}
