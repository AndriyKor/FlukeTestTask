using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fluke.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fluke.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Events : ControllerBase
    {
        private readonly IEventsRepository eventsRepository;

        public Events(IEventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var events = await eventsRepository.GetEventsAllAsync();
            if (events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var events = await eventsRepository.GetEventDetails(id);
            if (events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }
    }
}
