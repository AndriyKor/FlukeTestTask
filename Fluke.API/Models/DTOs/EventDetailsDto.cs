using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluke.API.Models
{
    public class EventDetailsDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<Category> Categories { get; set; }
        public List<Source> Sources { get; set; }
    }
}
