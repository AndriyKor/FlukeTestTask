﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluke.API.Models
{
    public class Geometry
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public List<float> Сoordinates { get; set; }
    }
}
