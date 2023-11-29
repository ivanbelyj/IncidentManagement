using IncidentManagement.Services.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.Events.Sending;
/// <summary>
/// Sends the generated event to the Processor
/// </summary>
public interface IEventSender
{
    Task Send(EventModel eventModel);
}
