using IncidentManagement.Common.Enums;
using IncidentManagement.Services.Events.Models;
using System;

namespace IncidentManagement.EventGenerator;

public static class EventGenerationUtils
{
    public static GenerateEventModel GetRandomGenerateEventModel()
    {
        Random rnd = new Random();
        Array values = Enum.GetValues(typeof(EventType));
        EventType randomType = (EventType)values.GetValue(rnd.Next(values.Length))!;
        return new GenerateEventModel()
        {
            Type = randomType
        };
    }
}
