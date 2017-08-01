using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilluke.EventStore.Models;

namespace Tilluke.EventStore.Services
{
    public class EventRepository
    {
        private readonly List<Event> events = new List<Event>();

        public void Register(Event @event)
        {
            this.events.Add(@event);
        }

        public IEnumerable<Event> Get()
        {
            return this.events.ToList();
        }
    }
}
