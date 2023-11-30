using IncidentManagement.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Context.Entities;
public class Event : EntityBase
{
    public EventType Type { get; set; }
    public DateTime Time { get; set; } = DateTime.UtcNow;
    public Guid? DerivedIncidentId { get; set; }
    public virtual Incident? DerivedIncident { get; set; }
}
