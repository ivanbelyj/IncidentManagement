using IncidentManagement.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventsProcessing.Models;
public class ProcessEventModel
{
    //public Guid Id { get; set; }
    public EventType Type { get; set; }
    public DateTime Time { get; set; }
}
