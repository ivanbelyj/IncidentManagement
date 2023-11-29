using AutoMapper;
using IncidentManagement.Common.Enums;
using IncidentManagement.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventProcessing.Models;
public class AddIncidentModel
{
    public IncidentType Type { get; set; }
}

public class AddIncidentModelProfile : Profile
{
    public AddIncidentModelProfile()
    {
        CreateMap<AddIncidentModel, Incident>();
    }
}
