using Fluke.Domain.Models;
using Fluke.Domain.Models.Options;
using Newtonsoft.Json;
using Fluke.Domain.Base;
using Microsoft.Extensions.Options;

namespace Fluke.API.Repository
{
    public class CategoryRepository(IOptions<EONETConfiguration> config) : ICategoryRepository
    {
        private readonly EONETConfiguration _config = config.Value;

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var result = new List<Category>();
            
            using var client = new HttpClient();
            var response = await client.GetAsync(_config.Urls.Categories);
            
            if (!response.IsSuccessStatusCode) 
                return result;
            
            var content = await response.Content.ReadAsStringAsync();
            var categoriesAll = JsonConvert.DeserializeObject<CategoriesAll>(content);
            result = categoriesAll?.Categories ?? [];

            return result;
        }
    }
}
