using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tilluke.Backups.Models;

namespace Tilluke.Backups.Controllers
{
    [Route("api/[controller]")]
    public class BackupsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Backup> Get()
        {
            return new[]
            {
                new Backup
                {
                    Start = new DateTime(2017, 07, 25, 06, 30, 00),
                    End = new DateTime(2017, 07, 25, 06, 49, 53),
                    Duration = new TimeSpan(0, 19, 53),
                    Name = "Violette/Data",
                    Size = 1981210,
                },
                new Backup
                {
                    Start = new DateTime(2017, 07, 26, 06, 30, 00),
                    End = new DateTime(2017, 07, 26, 06, 48, 02),
                    Duration = new TimeSpan(0, 18, 02),
                    Name = "Violette/Data",
                    Size = 1981986,
                },
            };
        }
    }
}
