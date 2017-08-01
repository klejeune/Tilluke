using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tilluke.EventStore.Models
{
    public class Event
    {
        public DateTime OccuredAt { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string ResourceId { get; set; }
        public object Data { get; set; }
    }
}
