using System;

namespace Tilluke.Backups.Models
{
    public class Backup
    {
        public string Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Name { get; set; }
        public long? Size { get; set; }
    }
}