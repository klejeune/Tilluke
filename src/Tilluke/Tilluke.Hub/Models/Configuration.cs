using System.Collections.Generic;

namespace Tilluke.Hub.Models
{
    public class Configuration
    {
        public IEnumerable<string> EventStores { get; set; }
    }
}