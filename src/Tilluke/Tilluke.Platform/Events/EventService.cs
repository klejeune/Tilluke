using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tilluke.Platform.Events.Models;
using Tilluke.Platform.Hubs;

namespace Tilluke.Platform.Events
{
    public class EventService
    {
        private readonly HubService hubService;

        public EventService(HubService hubService)
        {
            this.hubService = hubService;
        }

        private EventStoreAPI GetApi()
        {
            var eventStoreUri = this.hubService.GetHub().GetEventStoreUri();

            return new EventStoreAPI(eventStoreUri, null);
        }

        public void RegisterEvent(Event @event)
        {
            this.GetApi().ApiEventsPost(new EventModel
            {
                Id = @event.Id,
                OccuredAt = @event.OccuredAt,
                ResourceId = @event.ResourceId,
                Type = @event.Type,
                Data = @event.Data,
            });
        }

        public IEnumerable<Event> GetEvents()
        {
            return this.GetApi().ApiEventsGet().Select(e => new Event
            {
                Id = e.Id,
                OccuredAt = (DateTime)e.OccuredAt,
                ResourceId = e.ResourceId,
                Type = e.Type,
                Data = e.Data,
            });
        }
    }
}
