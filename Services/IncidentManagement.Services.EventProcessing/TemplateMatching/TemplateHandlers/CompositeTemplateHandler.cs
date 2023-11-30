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

        return (eventModel.Type == EventType.Type1
            && lastProcessedType2Event != null
            && (eventModel.Time - lastProcessedType2Event.Time)
                .TotalSeconds <= 20);
    }

    public TemplateMatchingResult HandleEvent(ProcessEventModel eventModel)
    {
        bool isMatched = ProcessAndMatchEvent(eventModel);
        if (isMatched)
        {
            var addIncidentModel = new AddIncidentModel()
            {
                Type = IncidentType.Type2
            };
            var res = TemplateMatchingResult.Succeed(addIncidentModel, new[]
            {
                eventModel, lastProcessedType2Event!
            });

            // One Type2 event - one Type2 incident
            lastProcessedType2Event = null;

            return res;
        }
        else
            return TemplateMatchingResult.NotMatched;
    }
}
