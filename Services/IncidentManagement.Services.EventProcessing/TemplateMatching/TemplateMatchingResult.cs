using IncidentManagement.Services.EventProcessing.Models;
using IncidentManagement.Services.EventsProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventProcessing.TemplateMatching;
public class TemplateMatchingResult
{
    public bool IsMatched { get; private set; }
    public AddIncidentModel? AddIncidentModel { get; private set; }
    public ProcessEventModel[]? BaseProcessEventModels { get; private set; }

    public TemplateMatchingResult(bool isMatched, AddIncidentModel? incident,
        ProcessEventModel[]? baseEvents)
    {
        IsMatched = isMatched;
        AddIncidentModel = incident;
        BaseProcessEventModels = baseEvents;
    }

    public static TemplateMatchingResult NotMatched
        => new TemplateMatchingResult(false, null, null);
    public static TemplateMatchingResult Succeed(AddIncidentModel incident,
        ProcessEventModel[] baseEvents)
        => new TemplateMatchingResult(true, incident, baseEvents);
}
