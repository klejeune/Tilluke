using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tilluke.Backups.Services;
using Tilluke.Platform;
using Tilluke.Platform.Events;
using Tilluke.Platform.Hubs;

namespace Tilluke.Backups
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddHangfire(config =>
            {
                config.UseMemoryStorage();
                //config.UseSqlServerStorage(Configuration["Data:WorkQueue"]);
            });

            services.AddTillukePlatform("http://localhost:53434", "http://tilluke.local.localhost/Hub1/", "http://tilluke.local.localhost/Hub2/");
            services.AddSingleton<BackupRepository>();
            services.AddTransient<BackupService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
            app.UseHangfireServer();

            var a = serviceProvider.GetService<BackupService>();

            RecurringJob.AddOrUpdate(() => serviceProvider.GetService<BackupService>().Run(), Cron.Minutely);
        }
    }
}
