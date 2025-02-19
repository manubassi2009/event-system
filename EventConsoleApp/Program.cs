// See https://aka.ms/new-console-template for more information
using EventConsoleApp.Factory;
using EventConsoleApp;

//Console.WriteLine("Hello, World!");
//Console.WriteLine("Creating Events and Processing Queue\n");

//// Create Events
//var reminderEvent = EventFactory.CreateEvent("Reminder", "INC123", new Dictionary<string, object> { { "DaysPending", 5 } });
//var escalationEvent = EventFactory.CreateEvent("Escalation", "INC456", new Dictionary<string, object> { { "EscalationLevel", "High" } });

//// Add Events to Queue
//EventProcessor.AddToQueue(reminderEvent);
//EventProcessor.AddToQueue(escalationEvent);

//// Process Queue
//await EventProcessor.ProcessQueueAsync();

Console.WriteLine("Checking Incidents and Applying Rules\n");

//var incidents = new List<Dictionary<string, object>>
//        {
//            new Dictionary<string, object> { { "IncidentId", "INC123" }, { "Status", "Incomplete" }, { "DaysPending", 2 } },
//            new Dictionary<string, object> { { "IncidentId", "INC456" }, { "Status", "Incomplete" }, { "DaysPending", 7 } }
//        };
//var rules = RuleEngine.GetRules();
//foreach (var incident in incidents)
//{
//    foreach (var rule in rules)
//    {
//        if (incident["Status"].ToString() == rule["Status"].ToString() &&
//            Convert.ToInt32(incident["DaysPending"]) == Convert.ToInt32(rule["DaysPending"]))
//        {
//            var eventObj = EventFactory.CreateEvent(rule["EventType"].ToString(), incident["IncidentId"].ToString(), rule);
//            EventProcessor.AddToQueue(eventObj);
//        }
//    }
//}
var incidents = new List<Incident>
        {
            new Incident { IncidentId = "INC123", Status = "Incomplete", CreatedDate = DateTime.UtcNow.AddDays(-2) },
            new Incident { IncidentId = "INC456", Status = "Incomplete", CreatedDate = DateTime.UtcNow.AddDays(-7) },
            new Incident { IncidentId = "INC789", Status = "Resolved", CreatedDate = DateTime.UtcNow.AddDays(-5) }
        };

var rules = RuleEngine.GetRules();
foreach (var incident in incidents)
{
    foreach (var rule in rules)
    {
        if (incident.Status == rule["Status"].ToString() &&
            (DateTime.UtcNow - incident.CreatedDate).Days == Convert.ToInt32(rule["DaysPending"]))
        {
            var eventObj = EventFactory.CreateEvent(rule["EventType"].ToString(), incident.IncidentId, rule);
            EventProcessor.AddToQueue(eventObj);
        }
    }
}


// Process Queue
await EventProcessor.ProcessQueueAsync(incidents);