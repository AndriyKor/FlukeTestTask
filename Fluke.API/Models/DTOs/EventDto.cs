﻿using System;

namespace Fluke.API.Models
{
    public class EventDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ClosedDate { get; set; }
    }
}
