using Fluke.Domain.Models;

namespace Fluke.Domain.Base
{
    public class Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public DateTime? Closed { get; set; }
        public List<Category> Categories { get; set; }
        public List<Source> Sources { get; set; }
        public List<Geometry> Geometry { get; set; }
    }
}
