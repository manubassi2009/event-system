using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventConsoleApp
{
    public interface IEvent
    {
        string EventId { get; }
        DateTime CreatedAt { get; }
        //void Process();
        void Process(List<Incident> incidents);
    }
}
