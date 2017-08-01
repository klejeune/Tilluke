using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tilluke.Backups.Events;
using Tilluke.Backups.Models;

namespace Tilluke.Backups.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        [HttpGet]
        public IEnumerable<IEvent> Get()
        {
            return new IEvent[]
            {
                new BackupStarted
                {
                    Id = "1",
                    Start = new DateTime(2017, 07, 25, 06, 30, 00),
                    Name = "Violette/Data",
                    OccuredAt = new DateTime(2017, 07, 25, 06, 30, 00),
                },
                new BackupEnded
                {
                    Id = "1",
                    End = new DateTime(2017, 07, 26, 06, 49, 53),
                    Size = 1981986,
                    OccuredAt = new DateTime(2017, 07, 25, 06, 49, 53),
                },
                new BackupStarted
                {
                    Id = "2",
                    Start = new DateTime(2017, 07, 25, 06, 30, 00),
                    Name = "Violette/Data",
                    OccuredAt = new DateTime(2017, 07, 25, 06, 30, 00),
                },
                new BackupEnded
                {
                    Id = "2",
                    End = new DateTime(2017, 07, 26, 06, 48, 02),
                    Size = 1981986,
                    OccuredAt = new DateTime(2017, 07, 25, 06, 48, 02),
                },
            };
        }
    }
}
