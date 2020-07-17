using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluke.API.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public List<Category> Categories { get; set; }
        public List<Source> Sources { get; set; }
        public List<Geometry> Geometries { get; set; }
    }
}
