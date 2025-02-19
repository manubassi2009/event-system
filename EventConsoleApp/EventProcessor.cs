using EventConsoleApp.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventConsoleApp
{
    public class EventProcessor
    {
        private static Queue<string> eventQueue = new();

        public static void AddToQueue(IEvent eventObj)
        {
            string jsonData = JsonSerializer.Serialize(new { EventType = eventObj.GetType().Name, EventData = eventObj });
            eventQueue.Enqueue(jsonData);
        }

        public static async Task ProcessQueueAsync(List<Incident> incidents)
        {
            while (eventQueue.Count > 0)
            {
                string jsonMessage = eventQueue.Dequeue();
                var message = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonMessage);
                string eventType = message["EventType"].ToString();
                var eventData = JsonSerializer.Deserialize<Dictionary<string, object>>(message["EventData"].ToString());

                IEvent eventObj = EventFactory.CreateEvent(eventType, eventData["IncidentId"].ToString(), eventData);
                eventObj.Process(incidents);
                await Task.Delay(500); // Simulate processing delay
            }
        }
    }
}
