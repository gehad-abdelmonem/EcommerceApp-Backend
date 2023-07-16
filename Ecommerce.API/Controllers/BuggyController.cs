using Ecommerce.API.Errors;
using Ecommerce.DAL.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext context;
        public BuggyController(StoreContext _context)
        {
            context = _context;
        }
        [HttpGet]
        [Route("notFound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = context.Products.Find(50);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }

        [HttpGet("serverError")]
        public IActionResult GetServerError()
        {
            var thing = context.Products.Find(50);
            var thingToString = thing.ToString();
            return Ok();
        }

        [HttpGet("badRquest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        
    }
}
