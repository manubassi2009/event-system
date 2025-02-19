using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventConsoleApp
{
    public class EscalationEvent : IEvent
    {
        public string EventId { get; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public string IncidentId { get; set; }
        public string EscalationLevel { get; set; }

        //public void Process()
        //{
        //    Console.WriteLine($"[Escalation] Escalating Incident {IncidentId} to {EscalationLevel}.");
        //}

        public void Process(List<Incident> incidents)
        {
            var incident = incidents.FirstOrDefault(i => i.IncidentId == IncidentId);
            if (incident != null && incident.Status == "Incomplete")
            {
                Console.WriteLine($"[Escalation] Escalating Incident {IncidentId} to {EscalationLevel}.");
            }
            else
            {
                Console.WriteLine($"[Escalation] Skipping Incident {IncidentId} as status changed.");
            }
        }
    }
}
