using AutoMapper;
using IncidentManagement.Common.Enums;
using IncidentManagement.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.Events.Models;
public class EventModel
{
    //public Guid Id { get; set; }
    public EventType Type { get; set; }
    public DateTime Time { get; set; }
}

//public class EventModelProfile : Profile
//{
//    public EventModelProfile()
//    {
//        CreateMap<Event, EventModel>();
//    }
//}
