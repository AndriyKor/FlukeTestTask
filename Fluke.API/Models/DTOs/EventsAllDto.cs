using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluke.API.Models
{
    public class EventsAllDto
    {
        public string Title { get; set; }
        public List<EventDetailsDto> Events { get; set; }
    }
}
