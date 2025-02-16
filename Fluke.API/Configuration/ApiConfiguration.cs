using Fluke.API.EndpointGroups;

namespace Fluke.API.Configuration;

public static class ApiConfiguration
{
    public static void MapApiEndpoints(this WebApplication app)
    {
        var apiGroups = new List<IApiGroup>
        {
            new EventsGroup(),
            new CategoriesGroup(),
        };

        foreach (var group in apiGroups)
        {
            group.MapEndpoints(app);
        }
    }
}