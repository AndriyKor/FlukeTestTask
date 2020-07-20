using System.Threading.Tasks;
using Fluke.Domain.Models;
using Fluke.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fluke.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Events : ControllerBase
    {
        private readonly IEventService _eventService;

        public Events(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]FilterModel filter, [FromQuery]OptionsModel options)
        {
            var result = await _eventService.GetList(filter, options);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _eventService.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
