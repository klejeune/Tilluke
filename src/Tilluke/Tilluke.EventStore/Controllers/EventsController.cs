using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tilluke.EventStore.Models;
using Tilluke.EventStore.Services;

namespace Tilluke.EventStore.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly EventRepository eventRepository;

        public EventsController(EventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return this.eventRepository.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Event Get(string id)
        {
            return this.eventRepository.Get().FirstOrDefault(e => e.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Event @event)
        {
            this.eventRepository.Register(@event);
        }
        
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
