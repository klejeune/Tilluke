using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tilluke.Hub.Models;

namespace Tilluke.Hub.Controllers
{
    [Route("api/[controller]")]
    public class ConfigurationController : Controller
    {
        // GET api/values
        [HttpGet]
        public Configuration Get()
        {
            return new Configuration
            {
                EventStores = new []
                {
                    "http://tilluke.local.localhost/EventStore1"
                }
            };
        }
    }
}
