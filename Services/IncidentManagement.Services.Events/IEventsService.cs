using IncidentManagement.Services.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.Events;
public interface IEventsService
{
    /// <summary>
    /// Creates an event and sends it
    /// </summary>
    Task<EventModel> GenerateEvent(GenerateEventModel model);
}
