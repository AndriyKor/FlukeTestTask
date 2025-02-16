using Fluke.API.Services;

namespace Fluke.API.EndpointGroups;

public class CategoriesGroup : IApiGroup
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/categories");

        group.MapGet("/", async (ICategoryService categoryService) =>
        {
            var result = await categoryService.GetAll();
            return Results.Ok(result);
        })
        .WithName("GetCategories");
    }
}