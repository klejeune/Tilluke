using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tilluke.Backups.Models;
using Tilluke.Platform.Events;

namespace Tilluke.Backups.Services
{
    public class BackupService
    {
        private readonly EventService eventService;
        private readonly BackupRepository backupRepository;
        private readonly TimeSpan backupFrequency = TimeSpan.FromSeconds(30);

        public BackupService(EventService eventService, BackupRepository backupRepository)
        {
            this.eventService = eventService;
            this.backupRepository = backupRepository;
        }

        public void Run()
        {
            var lastBackup = this.backupRepository.Get().OrderBy(b => b.Start).LastOrDefault();

            if (lastBackup == null || DateTime.Now - lastBackup.Start >= backupFrequency)
            {
                this.Backup();
            }
        }

        public void Backup()
        {
            var backup = new Backup
            {
                Id = Guid.NewGuid().ToString("N"),
                Start = new DateTime(2017, 07, 25, 06, 30, 00),
                Name = "Violette/Data",
            };

            this.backupRepository.Save(backup);

            this.eventService.RegisterEvent(new Event
            {
                OccuredAt = DateTime.Now,
                Id = Guid.NewGuid().ToString("N"),
                ResourceId = backup.Id,
                Type = "BackupStarted",
                Data = new
                {
                    Start = backup.Start,
                    Name = backup.Name,
                },
            });

            Thread.Sleep(TimeSpan.FromSeconds(5));

            backup.End = new DateTime(2017, 07, 25, 06, 49, 53);
            backup.Size = 1981210;
            backup.Duration = backup.End - backup.Start;
            this.backupRepository.Save(backup);

            this.eventService.RegisterEvent(new Event
            {
                OccuredAt = DateTime.Now,
                Id = Guid.NewGuid().ToString("N"),
                ResourceId = backup.Id,
                Type = "BackupEnded",
                Data = new
                {
                    End = backup.End,
                    Size = backup.Size,
                },
            });
        }
    }
}