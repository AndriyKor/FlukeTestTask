using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluke.API.Models
{
    public class Geometry
    {
        public string Date { get; set; }
        public string Type { get; set; }
        public int[] Coordinates { get; set; }
    }
}
