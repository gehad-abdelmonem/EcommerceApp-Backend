using Ecommerce.API.Errors;
using Ecommerce.BL.Dtos.Product;
using Ecommerce.BL.Helpers;
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
        [HttpPost]
        public async Task<ActionResult<ReadProductDto>> Add(WriteProductDto product)
        {
            return await productService.AddProduct(product);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await productService.DeleteProduct(id);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult>Update(int id,UpdateProductDto updateProductDto)
        {
            if (id != updateProductDto.id) return NotFound();
             await productService.UpdatProduct(id, updateProductDto);
            return NoContent();
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
            if (result == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return result;
        }
        [HttpGet]
        [Route("paginate")]
        public async Task<ActionResult<PagedCollectionResponse<ReadProductDto>>> Get([FromQuery] ProductParams productParams)
        {
            return await productService.Get(productParams);
        }

        [HttpGet]
        [Route("related/{categoryId}/{productId}/{productCont}")]
        public async Task<ActionResult<List<ReadProductDto>>> GetRelatedProducts(int categoryId, int productId, int productCont)
        {
            return await productService.GetRelatedProducts(categoryId, productId, productCont);
        }
          
    }
}
