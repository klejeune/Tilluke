
using System;

namespace Tilluke.Backups.Events
{
    public class BackupStarted : IEvent
    {
        public DateTime OccuredAt { get; set; }
        public string Id { get; set; }
        public DateTime Start { get; set; }
        public string Name { get; set; }
    }
}