using System;

namespace Tilluke.Backups.Events
{
    public interface IEvent
    {
        DateTime OccuredAt { get; }
        string Id { get; }
    }
}