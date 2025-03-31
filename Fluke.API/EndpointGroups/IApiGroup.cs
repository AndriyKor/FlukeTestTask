namespace Fluke.API.EndpointGroups;

public interface IApiGroup
{
    void MapEndpoints(IEndpointRouteBuilder app);
}