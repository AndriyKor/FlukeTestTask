using Fluke.Domain.Base;

namespace Fluke.API.Repository
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllAsync();
    }
}
