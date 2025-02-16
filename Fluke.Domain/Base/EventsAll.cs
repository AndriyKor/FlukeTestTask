using Fluke.Domain.Models;

namespace Fluke.Domain.Base
{
    public class EventsAll
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Event> Events { get; set; }
    }
}
