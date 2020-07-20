using System.Collections.Generic;

namespace Fluke.Domain.Models
{
    public class EventsAll
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Event> Events { get; set; }
    }
}
