using IncidentManagement.Common.Enums;
using IncidentManagement.Services.EventProcessing.Models;
using IncidentManagement.Services.EventsProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventProcessing.TemplateMatching.TemplateHandlers;
public class SimpleTemplateHandler : ITemplateHandler
{
    private bool MatchEvent(ProcessEventModel eventModel)
    {
        return eventModel.Type == EventType.Type1;
    }

    private AddIncidentModel CreateIncident()
    {
        return new AddIncidentModel()
        {
            Type = IncidentType.Type1
        };
    }

    public (bool isMatched, AddIncidentModel? incident) HandleEvent(
        ProcessEventModel eventModel)
    {
        bool isMatched = MatchEvent(eventModel);
        return (isMatched, isMatched ? CreateIncident() : null);
    }
}
