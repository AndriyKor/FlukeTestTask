using System.Threading.Tasks;
using Fluke.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fluke.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
