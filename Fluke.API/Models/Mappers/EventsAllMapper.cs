using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluke.API.Models.Extentions
{
    public static class EventsAllMapper
    {
        public static EventsAllDto MapToDto(this EventsAll eventsAll) => new EventsAllDto
        {
            Title = eventsAll.Title,
            Events = eventsAll.Events.Select(e => e.MapToDto()).ToList()
        };
    }
}
