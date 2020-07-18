using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluke.API.Models.Extentions
{
    public static class EventDetailsMapper
    {
        public static EventDetailsDto MapToDto(this EventDetails eventDetails) => new EventDetailsDto
        {
            Id = eventDetails.Id,
            Title = eventDetails.Title,
            Categories = eventDetails.Categories,
            Sources = eventDetails.Sources
        };
    }
}
