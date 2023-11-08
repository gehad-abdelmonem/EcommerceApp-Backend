using Ecommerce.BL.Dtos.ProductCategory;
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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ReadCategoryDto>> GetById(int id)
        {
            var category=await categoryService.GetById(id);
            if(category == null) { return NotFound(); }
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<ReadCategoryDto>> Add(WriteCategoryDto writeCategoryDto)
        {
            return await categoryService.AddCategory(writeCategoryDto);
             
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task <ActionResult> Delete(int id)
        {
            bool result = await categoryService.DeleteCategory(id);
            if(result==false) { return NotFound(); }
            return Ok(true);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task <ActionResult> Update(int id,UpdateCategoryDto category)
        {
            if(id!=category.id) return BadRequest();
            var result = await categoryService.UpdateCategory(id, category);
            if (result == null) return NotFound();
            return NoContent();
        }
    }
}
