using Fluke.Domain.Models;

namespace Fluke.API.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAll();
    }
}
