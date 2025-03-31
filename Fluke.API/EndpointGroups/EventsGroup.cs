using Fluke.API.Services;
using Fluke.Domain.Filters;

namespace Fluke.API.EndpointGroups;

public class EventsGroup : IApiGroup
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        var eventsGroup = app.MapGroup("/api/events");

        eventsGroup.MapGet("/", async (
                [AsParameters] FilterModel filter,
                [AsParameters] OptionsModel options,
                IEventService eventService) =>

            {
                var result = await eventService.GetList(filter, options);
                return Results.Ok(result);
            })
            .WithName("GetEvents");

        eventsGroup.MapGet("/{id}", async (
                string id,
                IEventService eventService) =>
            {
                var result = await eventService.Get(id);
                return Results.Ok(result);
            })
            .WithName("GetEventById");
    }
}