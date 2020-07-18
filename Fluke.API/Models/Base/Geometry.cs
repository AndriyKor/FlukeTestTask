using System;
using System.Collections.Generic;

namespace Fluke.API.Models
{
    public class Geometry
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public List<float> Сoordinates { get; set; }
    }
}
