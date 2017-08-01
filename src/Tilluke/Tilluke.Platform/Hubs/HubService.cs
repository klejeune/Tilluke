using System;
using System.Collections.Generic;
using System.Linq;

namespace Tilluke.Platform.Hubs
{
    public class HubService
    {
        private readonly List<Uri> hubUrls;

        public HubService(IEnumerable<Uri> hubUrls)
        {
            this.hubUrls = hubUrls.ToList();
        }

        public Hub GetHub()
        {
            var url = this.hubUrls.FirstOrDefault();

            if (url == null)
            {
                throw new InvalidOperationException("No hub could be found");
            }

            return new Hub(url);
        }
    }
}