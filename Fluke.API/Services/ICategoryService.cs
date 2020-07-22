using Fluke.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fluke.API.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAll();
    }
}
