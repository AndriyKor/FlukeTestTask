using System;
using System.Collections.Generic;

namespace Fluke.Domain.Models
{
    public class Geometry
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public List<float> Сoordinates { get; set; }
    }
}
