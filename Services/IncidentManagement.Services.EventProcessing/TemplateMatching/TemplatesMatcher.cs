using IncidentManagement.Services.EventProcessing.Models;
using IncidentManagement.Services.EventsProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventProcessing.TemplateMatching;

// Using template handlers pipeline approach, we can easily add
// new templates and define their priorities (via handlers order)
public class TemplatesMatcher
{
    private readonly IEnumerable<ITemplateHandler> templateHandlers;

    public TemplatesMatcher(IEnumerable<ITemplateHandler> templateHandlers)
	{
        this.templateHandlers = templateHandlers;
    }

    public AddIncidentModel? MatchAndCreateIncident(ProcessEventModel eventModel)
    {
        foreach (var handler in templateHandlers)
        {
            var (isMatched, incident) = handler.HandleEvent(eventModel);
            if (isMatched)
            {
                // Return an incident of the first matching template
                return incident;
            }
        }

        return null;
    }
}
