using System;

namespace Tilluke.Backups.Events
{
    public class BackupEnded : IEvent
    {
        public DateTime OccuredAt { get; set; }
        public string Id { get; set; }
        public DateTime? End { get; set; }
        public long? Size { get; set; }
    }
}