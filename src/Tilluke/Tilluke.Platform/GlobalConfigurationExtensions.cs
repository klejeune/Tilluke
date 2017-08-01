using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tilluke.Platform.Events;
using Tilluke.Platform.Hubs;

namespace Tilluke.Platform
{
    public static class GlobalConfigurationExtensions
    {
        public static IServiceCollection AddTillukePlatform(this IServiceCollection services, params string[] hubUrls)
        {
            services.TryAddSingleton(new HubService(hubUrls.Select(u => new Uri(u))));
            services.TryAddTransient<EventService>();

            return services;
        }
    }
}