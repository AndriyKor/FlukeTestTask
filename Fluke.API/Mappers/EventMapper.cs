using Fluke.Domain.Base;
using Fluke.Domain.Models;

namespace Fluke.API.Mappers
{
    public static class EventMapper
    {
        public static EventDto MapToDto(this Event eventDetails) => new()
        {
            Id = eventDetails.Id,
            Title = eventDetails.Title,
            Link = eventDetails.Link,
            Status = eventDetails.Closed == null ? "open" : "closed",
            Category = eventDetails.Categories[0].Title,
            Date = eventDetails.Geometry[0].Date,
            ClosedDate = eventDetails.Closed,
        };
    }
}
