using Fluke.Domain.Base;
using Fluke.Domain.Models;

namespace Fluke.API.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto MapToDto(this Category categoryDetails) => new CategoryDto
        {
            Id = categoryDetails.Id,
            Title = categoryDetails.Title,
        };
    }
}
