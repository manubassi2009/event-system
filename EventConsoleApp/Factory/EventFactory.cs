using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventConsoleApp.Factory
{
    public class EventFactory
    {
        //public static IEvent CreateEvent(string eventType, string incidentId, Dictionary<string, object> eventData)
        //{
        //    return eventType switch
        //    {
        //        "Reminder" => new ReminderEvent
        //        {
        //            IncidentId = incidentId,
        //            DaysPending = Convert.ToInt32(eventData["DaysPending"])
        //        },
        //        "Escalation" => new EscalationEvent
        //        {
        //            IncidentId = incidentId,
        //            EscalationLevel = eventData["EscalationLevel"].ToString()
        //        },
        //        _ => throw new NotImplementedException($"Unknown event type: {eventType}")
        //    };
        //}

        public static IEvent CreateEvent(string eventType, string incidentId, Dictionary<string, object> eventData)
        {
            return eventType switch
            {
                "Reminder" => new ReminderEvent
                {
                    IncidentId = incidentId,
                    DaysPending = Convert.ToInt32(eventData["DaysPending"])
                },
                "Escalation" => new EscalationEvent
                {
                    IncidentId = incidentId,
                    EscalationLevel = eventData.ContainsKey("EscalationLevel") ? eventData["EscalationLevel"].ToString() : "DefaultLevel"
                },
                _ => throw new NotImplementedException($"Unknown event type: {eventType}")
            };
        }

    }
}
