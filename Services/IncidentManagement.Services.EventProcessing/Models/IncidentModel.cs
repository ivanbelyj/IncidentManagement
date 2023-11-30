using AutoMapper;
using IncidentManagement.Common.Enums;
using IncidentManagement.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventProcessing.Models;
public class IncidentModel
{
    public Guid Id { get; set; }
    public IncidentType Type { get; set; }
    public DateTime Time { get; set; }
    public ICollection<EventModel>? BaseEvents { get; set; }
}

public class IncidentModelProfile : Profile
{
    public IncidentModelProfile()
    {
        CreateMap<Incident, IncidentModel>();
    }
}
