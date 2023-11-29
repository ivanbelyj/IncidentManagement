using IncidentManagement.Common.Enums;
using IncidentManagement.Services.EventProcessing.Models;
using IncidentManagement.Services.EventsProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventProcessing.TemplateMatching.TemplateHandlers;
public class CompositeTemplateHandler : ITemplateHandler
{
    private ProcessEventModel? lastProcessedType2Event;

    private bool ProcessAndMatchEvent(ProcessEventModel eventModel)
    {
        if (eventModel.Type == EventType.Type2)
            lastProcessedType2Event = eventModel;

        if (eventModel.Type == EventType.Type1
            && lastProcessedType2Event != null
            && (eventModel.Time - lastProcessedType2Event.Time)
                .TotalSeconds <= 20)
        {
            // One Type2 event - one Type2 incident
            lastProcessedType2Event = null;
            return true;
        }
        return false;
    }

    public AddIncidentModel CreateIncident(ProcessEventModel eventModel)
    {
        return new AddIncidentModel()
        {
            Type = IncidentType.Type2
        };
    }

    public (bool isMatched, AddIncidentModel? incident) HandleEvent(
        ProcessEventModel eventModel)
    {
        bool isMatched = ProcessAndMatchEvent(eventModel);
        return (isMatched, isMatched ? CreateIncident(eventModel) : null);
    }
}
