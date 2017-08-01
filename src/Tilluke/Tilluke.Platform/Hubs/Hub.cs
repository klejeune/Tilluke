using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tilluke.Platform.Events;

namespace Tilluke.Platform.Hubs
{
    public class Hub
    {
        private readonly Uri uri;
        private HubAPI hubApi;

        public Hub(Uri uri)
        {
            this.uri = uri;
            this.hubApi = new HubAPI(uri, null);
        }

        public Uri GetEventStoreUri()
        {
            return new Uri(this.hubApi.ApiConfigurationGet().EventStores.FirstOrDefault());
        }
    }
}