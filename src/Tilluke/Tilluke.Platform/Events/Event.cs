using System;

namespace Tilluke.Platform.Events
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