using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventConsoleApp
{
    public static class RuleEngine
    {
        //public static List<Dictionary<string, object>> GetRules()
        //{
        //    return new List<Dictionary<string, object>>
        //{
        //    new Dictionary<string, object> { { "Status", "Incomplete" }, { "DaysPending", 2 }, { "EventType", "Reminder" } },
        //    new Dictionary<string, object> { { "Status", "Incomplete" }, { "DaysPending", 7 }, { "EventType", "Escalation" } }
        //};
        //}
        //public static List<Dictionary<string, object>> GetRules()
        //{
        //    return new List<Dictionary<string, object>>
        //{
        //    new Dictionary<string, object> { { "Status", "Incomplete" }, { "DaysPending", 2 }, { "EventType", "Reminder" } },
        //    new Dictionary<string, object> { { "Status", "Incomplete" }, { "DaysPending", 7 }, { "EventType", "Escalation" } }
        //};
        //}

        public static List<Dictionary<string, object>> GetRules()
        {
            return new List<Dictionary<string, object>>
    {
        new Dictionary<string, object> { { "Status", "Incomplete" }, { "DaysPending", 2 }, { "EventType", "Reminder" } },
        new Dictionary<string, object> { { "Status", "Incomplete" }, { "DaysPending", 7 }, { "EventType", "Escalation" }, { "EscalationLevel", "High" } }
    };
        }

    }
}
