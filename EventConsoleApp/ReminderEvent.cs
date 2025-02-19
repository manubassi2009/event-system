using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventConsoleApp
{
    public class ReminderEvent : IEvent
    {
        public string EventId { get; } = Guid.NewGuid().ToString();
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public string IncidentId { get; set; }
        public int DaysPending { get; set; }

        //public void Process()
        //{
        //    Console.WriteLine($"[Reminder] Sending email for Incident {IncidentId}, pending for {DaysPending} days.");
        //}

        public void Process(List<Incident> incidents)
        {
            var incident = incidents.FirstOrDefault(i => i.IncidentId == IncidentId);
            if (incident != null && incident.Status == "Incomplete")
            {
                Console.WriteLine($"[Reminder] Sending email for Incident {IncidentId}, pending for {DaysPending} days.");
            }
            else
            {
                Console.WriteLine($"[Reminder] Skipping Incident {IncidentId} as status changed.");
            }
        }
    }
}
