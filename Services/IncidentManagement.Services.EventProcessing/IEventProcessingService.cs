using IncidentManagement.Services.EventProcessing.Models;
using IncidentManagement.Services.EventsProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventsProcessing;

/// <summary>
/// A service that processes incoming events and creates incidents based on them
/// </summary>
public interface IEventProcessingService
{
    public Task ProcessEvent(ProcessEventModel model);
    public Task<IEnumerable<IncidentModel>> GetIncidents(
        int offset = 0,
        int limit = 10,
        bool sorted = true,
        bool orderByTimeDesc = true);
}
