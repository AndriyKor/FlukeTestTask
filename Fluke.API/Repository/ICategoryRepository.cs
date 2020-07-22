using Fluke.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fluke.API.Repository
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllAsync();
    }
}
