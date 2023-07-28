using Ecommerce.BL.Dtos.ProductType;
using Ecommerce.BL.Services.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ReadCategoryDto>>> GetAll()
        {
            return await categoryService.GetAll();
        }
    }
}
