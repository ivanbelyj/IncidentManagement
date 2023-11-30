using AutoMapper;
using IncidentManagement.Common.Enums;
using IncidentManagement.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventsProcessing.Models;

/// <summary>
/// DTO for event processing 
/// </summary>
public class ProcessEventModel
{
    public EventType Type { get; set; }
    public DateTime Time { get; set; }
}

public class ProcessEventModelProfile : Profile
{
    public ProcessEventModelProfile()
    {
        CreateMap<ProcessEventModel, Event>();
    }
}
