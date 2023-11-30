using IncidentManagement.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncidentManagement.Context.Entities;
public class Incident : EntityBase
{
    public IncidentType Type { get; set; }
    public DateTime Time { get; set; } = DateTime.UtcNow;
    public virtual ICollection<Event>? BaseEvents { get; set; }
}