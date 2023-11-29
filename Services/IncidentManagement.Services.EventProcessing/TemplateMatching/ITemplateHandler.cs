using IncidentManagement.Services.EventProcessing.Models;
using IncidentManagement.Services.EventsProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Services.EventProcessing.TemplateMatching;

/// <summary>
/// Handles processed events, matches required conditions and creates incident
/// if they are met
/// </summary>
public interface ITemplateHandler
{
    (bool isMatched, AddIncidentModel? incident) HandleEvent(
        ProcessEventModel eventModel);
}
