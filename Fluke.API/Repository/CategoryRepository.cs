using Fluke.Domain.Models;
using Fluke.Domain.Models.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fluke.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EONETConfiguration _config;

        public CategoryRepository(EONETConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var result = new List<Category>();
            using (var client = new HttpClient())
            {
                var responce = await client.GetAsync(_config.Urls.Categories);
                if (responce.IsSuccessStatusCode)
                {
                    var content = await responce.Content.ReadAsStringAsync();
                    var categoriesAll = JsonConvert.DeserializeObject<CategoriesAll>(content);
                    result = categoriesAll.Categories;
                }
            }
            return result;
        }
    }
}
