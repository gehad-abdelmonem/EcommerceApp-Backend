using Ecommerce.API.Errors;
using Ecommerce.BL.Dtos.Product;
using Ecommerce.BL.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : BaseApiController
    {
        private readonly IproductService productService;
        public productController(IproductService _productService)
        {
            productService = _productService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ReadProductDto>>> GetAll()
        {
            return await productService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadProductDto>> GetById(int id)
        {
            var result = await productService.GetById(id);
            if(result == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return result;
        }

    }
}
