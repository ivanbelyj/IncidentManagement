using IncidentManagement.Services.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.Events;

/// <summary>
/// A service that allows to generate events
/// </summary>
public interface IEventsService
{
    /// <summary>
    /// Creates an event and sends it
    /// </summary>
    Task<EventModel> GenerateAndSendEvent(GenerateEventModel model);
}
