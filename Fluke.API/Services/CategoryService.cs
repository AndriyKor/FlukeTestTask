using Fluke.API.Mappers;
using Fluke.Domain.Models;
using Fluke.API.Repository;

namespace Fluke.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var result = await _categoryRepository.GetAllAsync();
            return result.Select(e => e.MapToDto()).OrderBy(e => e.Id).ToList();
        }
    }
}
